using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Services.UnitOfWork;

namespace NetLine.Web.Areas.AdminPanel.Controllers
{
    public class CategoryManegerController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public CategoryManegerController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public async Task<IActionResult> ShowAllCategory()
        {
            var showCategory = await _iUnitOfWork.CategoryRe.ShowAllCategory();
            return View(showCategory);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category addCategory)
        {
            await _iUnitOfWork.CategoryRe.AddCategory(addCategory);
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id, Category addCategory)
        {
            var edit =await _iUnitOfWork.CategoryRe.EditCategory(id, addCategory);
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyEditCategory(Category addCategory)
        {
          await _iUnitOfWork.CategoryRe.ApplyEdit(addCategory);
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _iUnitOfWork.CategoryRe.DeleteCategory(id);
            return RedirectToAction("index", "Home");
        }
    }
}
