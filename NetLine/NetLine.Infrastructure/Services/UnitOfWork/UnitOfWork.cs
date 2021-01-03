using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Services.InterFaces;
using NetLine.Domain.Services.InterFaces.User.Cart;
using NetLine.Domain.Services.UnitOfWork;
using NetLine.Infrastructure.Context;
using NetLine.Infrastructure.Services.Repository.ProductAndCategory;

namespace NetLine.Infrastructure.Services.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly NetLineDbContext _context;

        public UnitOfWork(NetLineDbContext context)
        {
            ProductRe = new ProductRe(_context);
            _context = context;
        }
        public void Dispose()
        {
           _context. Dispose();
        }

        public IProductRe ProductRe { get; }
        public ICartRe CartRe { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
