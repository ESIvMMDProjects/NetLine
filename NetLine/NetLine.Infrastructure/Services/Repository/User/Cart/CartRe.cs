using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.User.Order;
using NetLine.Domain.Services.InterFaces.User.Cart;
using NetLine.Infrastructure.Context;

namespace NetLine.Infrastructure.Services.Repository.User.Cart
{
    public class CartRe : ICartRe
    {
        private readonly NetLineDbContext _context;

        public CartRe(NetLineDbContext context)
        {
            _context = context;
        }

            public async Task AddToCart(int itemId, string userId)
            {
                var product = await _context.Products.
                    Include(p => p.Item).
                    SingleOrDefaultAsync(p => p.ItemId == itemId);
                if (product != null)
                {
                    var order = await _context.Orders.FirstOrDefaultAsync(o => o.UserId == userId && !o.IsFinally);
                    if (order != null)
                    {
                        var orderDetail = await _context.OrderDetails
                            .FirstOrDefaultAsync(d => d.OrderId == order.OrderId && d.ProductId == product.Id);

                        if (orderDetail != null)
                        {
                        orderDetail.Count += 1;
                        }
                        else
                        {
                            await _context.OrderDetails.AddAsync(new OrderDetail()
                            {
                                OrderId = order.OrderId,
                                ProductId = product.Id,
                                Price = product.Item.Price,
                                Count = 1
                            });
                        }
                    }

                    else
                    {
                        order = new Order()
                        {
                            IsFinally = false,
                            CreateDate = DateTime.Now,
                            UserId = userId
                        };
                        await _context.Orders.AddAsync(order);
                        await _context.SaveChangesAsync();
                        await _context.OrderDetails.AddAsync(new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            ProductId = product.Id,
                            Price = product.Item.Price,
                            Count = 1
                        });
                    }

                    await _context.SaveChangesAsync();
                }
            }

            public async Task DeleteItemInCart(int detailId)
            {
            var orderDetail =await _context.OrderDetails.FindAsync(detailId);
            _context.Remove(orderDetail);
          await  _context.SaveChangesAsync();
            }
    }
    }

