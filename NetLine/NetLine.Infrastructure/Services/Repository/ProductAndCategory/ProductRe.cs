using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Services.InterFaces;
using NetLine.Domain.ViewModels.ProductAndCategory.Product;
using NetLine.Infrastructure.Context;

namespace NetLine.Infrastructure.Services.Repository.ProductAndCategory
{
    public class ProductRe :IProductRe
    {
        private readonly NetLineDbContext _context;

        public ProductRe(NetLineDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
          return  await _context.Products.ToListAsync();
        }

        public async Task<DetailViewModel> GetProductDetailById(int ProductId)
        {
            var Prodcut = await 
                _context.Products.Include(P => P.Item).
                    FirstOrDefaultAsync(p => p.ItemId == ProductId);

            var Category =await 
                _context.Products.Where(c => c.Id == ProductId).SelectMany(c => c.CategoryToProducts)
                    .Select(ca => ca.Category).ToListAsync();

            return new DetailViewModel()
            {
                product = Prodcut,
                Categories = Category
            };
        }
    }
}
