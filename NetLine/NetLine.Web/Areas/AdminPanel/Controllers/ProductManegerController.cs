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
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRe.AddProduct(add);
                return RedirectToAction("index", "Home");
            }

            return View();
        }

        //this Action for editProduct
        [HttpGet]
        public async Task<IActionResult> EditProdcut(int id, AddEditProdcutViewModel add)
        {
            var showEditPage = await _unitOfWork.ProductRe.EditProduct(id, add);
            return View(showEditPage);
        }
        //Apply Edit prodcut
        [HttpPost]
        public async Task<IActionResult> EditProdcut(AddEditProdcutViewModel add)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProductRe.ApplyEdit(add);
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        //this Action for DeleteProduct
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _unitOfWork.ProductRe.DeleteProduct(id);
            return RedirectToAction("index", "Home");
        }
    }
}