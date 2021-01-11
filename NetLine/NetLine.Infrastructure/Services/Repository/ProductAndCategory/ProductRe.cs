using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Services.InterFaces;
using NetLine.Domain.ViewModels.ProductAndCategory.Product;
using NetLine.Infrastructure.Context;

namespace NetLine.Infrastructure.Services.Repository.ProductAndCategory
{
    public class ProductRe : IProductRe
    {
        private readonly NetLineDbContext _context;

        public ProductRe(NetLineDbContext context)
        {
            _context = context;
        }

        //this method for GetAllProducts
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        //this method for GetProductById
        public async Task<DetailViewModel> GetProductDetailById(int ProductId)
        {
            var Prodcut = await
                _context.Products.Include(P => P.Item).
                    FirstOrDefaultAsync(p => p.ItemId == ProductId);

            var Category = await
                _context.Products.Where(c => c.Id == ProductId).SelectMany(c => c.CategoryToProducts)
                    .Select(ca => ca.Category).ToListAsync();

            //this method for show ProductDetail
            return new DetailViewModel()
            {
                product = Prodcut,
                Categories = Category
            };
        }


        //*************Manege-Product***************//


        //this method for AddProduct
        public async Task AddProduct(AddEditProdcutViewModel add)
        {
            var item = new Item()
            {
                Price = add.Price,
                QuantityInStock = add.QuantityInStock
            };
            await _context.AddAsync(item);
            await _context.SaveChangesAsync();
            var product = new Product()
            {
                Name = add.Name,
                Description = add.Description,
                Item = item,
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            if (add.UpPicture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(add.UpPicture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    add.UpPicture.CopyTo(stream);
                }
            }

        }

        //this method for show EditPage
        public async Task<AddEditProdcutViewModel> EditProduct(int id, AddEditProdcutViewModel add)
        {
            var product = await _context.Products.Include(p => p.Item)
                .Where(p => p.Id == id)
                .Select(s => new AddEditProdcutViewModel()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    QuantityInStock = s.Item.QuantityInStock,
                    Price = s.Item.Price
                }).FirstOrDefaultAsync();

            add = product;
            return add;
        }

        //this method for apply Edit
        public async Task ApplyEdit(AddEditProdcutViewModel add)
        {
            var product = await _context.Products.FindAsync(add.Id);
            var item = await _context.Items.FirstAsync(p => p.Id == product.ItemId);

            product.Name = add.Name;
            product.Description = add.Description;
            item.Price = add.Price;
            item.QuantityInStock = add.QuantityInStock;

            await _context.SaveChangesAsync();
            if (add.UpPicture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(add.UpPicture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    add.UpPicture.CopyTo(stream);
                }
            }
        }

        public async Task DeleteProduct(int id)
        {
            var Pr = _context.Products.FirstOrDefault(p => p.Id == id);
            var product = await _context.Products.FindAsync(Pr.Id);
            var item = await _context.Items.FirstAsync(p => p.Id == product.ItemId);
            _context.Items.Remove(item);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}
