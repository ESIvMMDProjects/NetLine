using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetLine.Domain.Services.UnitOfWork;
using NetLine.Domain.ViewModels.ProductAndCategory.Product;

namespace NetLine.Web.Areas.AdminPanel.Controllers
{
    public class ProductManegerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManegerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddEditProdcutViewModel add)
        {
           await _unitOfWork.ProductRe.AddProduct(add);
           return RedirectToAction("index", "Home");
        }
    }
}
