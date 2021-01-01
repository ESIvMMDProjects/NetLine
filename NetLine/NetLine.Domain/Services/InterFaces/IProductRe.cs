using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;

namespace NetLine.Domain.Services.InterFaces
{
    public interface IProductRe
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
