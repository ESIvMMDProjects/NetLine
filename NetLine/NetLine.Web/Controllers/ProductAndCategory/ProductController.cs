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
        private readonly ILogger _logger;

        public ProductController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        //This Action for Show All Products 
        public async Task<IActionResult> ShowProducts()
        {
         var AllProduct =  await  _unitOfWork.ProductRe.GetAllProducts();
            return View(AllProduct);
        }

    }
}
