using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Services.InterFaces;

namespace NetLine.Domain.Services.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
   {
       public IProductRe ProductRe { get; }
       Task SaveChangesAsync();
   }


}
