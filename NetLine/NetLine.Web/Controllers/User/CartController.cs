using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetLine.Domain.Services.UnitOfWork;
using NetLine.Infrastructure.Services.UnitOfWork;

namespace NetLine.Web.Controllers.User
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult AddToCart(int ItemId)
        {
            _unitOfWork.CartRe.AddToCart(ItemId);
            return View();
        }
    }
}
