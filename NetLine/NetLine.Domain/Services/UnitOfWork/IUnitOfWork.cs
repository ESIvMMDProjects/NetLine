using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Services.InterFaces;
using NetLine.Domain.Services.InterFaces.ProductAndCategory;
using NetLine.Domain.Services.InterFaces.User.Cart;

namespace NetLine.Domain.Services.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
   {
       ICategoryRe CategoryRe { get; }
       IProductRe ProductRe { get; }
        ICartRe CartRe { get; }
        Task SaveChangesAsync();
   }


}
