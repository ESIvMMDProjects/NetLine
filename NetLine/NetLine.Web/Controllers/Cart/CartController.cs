using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetLine.Domain.Services.UnitOfWork;

namespace NetLine.Web.Controllers.Cart
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> AddToCart(int itemId , string userId)
        {
          await  _unitOfWork.CartRe.AddToCart(itemId, userId);
          return RedirectToAction("index", "Home");
        }
    }
    }


