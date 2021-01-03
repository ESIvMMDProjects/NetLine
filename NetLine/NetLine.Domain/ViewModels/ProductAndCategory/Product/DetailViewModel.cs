using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;

namespace NetLine.Domain.ViewModels.ProductAndCategory.Product
{
   public class DetailViewModel
    {
        public IList<Category> Categories { get; set; }
        public Models.ProductAndCategory.Product product  { get; set; }
    }
}
