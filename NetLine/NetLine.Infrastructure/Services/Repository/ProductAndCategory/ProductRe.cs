using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Services.InterFaces;
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
    }
}
