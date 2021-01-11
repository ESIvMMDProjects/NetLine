using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;

namespace NetLine.Domain.ViewModels.ProductAndCategory.Product
{
    public class AddEditProdcutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public IFormFile UpPicture { get; set; }
        public List<Category> Category { get; set; }
    }
}
