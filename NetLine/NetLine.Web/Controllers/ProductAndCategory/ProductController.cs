using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NetLine.Domain.Services.UnitOfWork;


namespace NetLine.Web.Controllers.ProductAndCategory
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //This Action for Show All Products 
        [HttpGet]
        public async Task<IActionResult> ShowProducts()
        {
         var AllProduct =  await  _unitOfWork.ProductRe.GetAllProducts();
            return View(AllProduct);
        }

        //This Action for Show Product Detail
        [HttpGet]
        public async Task<IActionResult> DetailOfProduct(int ProductId)
        {
            var ShowDetailById =await _unitOfWork.ProductRe.GetProductDetailById(ProductId);
            if (ShowDetailById== null)
            {
                return NotFound();
            }
            return View(ShowDetailById);
        }
    }
}
