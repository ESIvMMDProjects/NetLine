﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.ViewModels.ProductAndCategory.Product;

namespace NetLine.Domain.Services.InterFaces
{
    public interface IProductRe
    {
        
        Task<IEnumerable<Product>> GetAllProducts();
        Task<DetailViewModel> GetProductDetailById(int ProductId);
        Task AddProduct(AddEditProdcutViewModel add);
        Task<AddEditProdcutViewModel> EditProduct(int id,AddEditProdcutViewModel add);
        Task ApplyEdit(AddEditProdcutViewModel add);
        Task DeleteProduct(int id);
    }
}
