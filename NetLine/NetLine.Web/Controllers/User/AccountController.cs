using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NetLine.Domain.ViewModels.Account;
using NetLine.Domain.ViewModels.Account.User;

namespace NetLine.Web.Controllers.User
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManeger;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            _userManeger = userManager;
            _signInManager = signInManager;
        }

        //this action for Register user
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    EmailConfirmed = true
                };
                var result = await _userManeger.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    RedirectToAction("index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        //this Action for login user
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (_signInManager.IsSignedIn(User))
            {
                RedirectToAction("index", "Home");
            }

            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model , string returnUrl = null)
        {
            if (ModelState.IsValid)
            {

                if (_signInManager.IsSignedIn(User))
                {
                    RedirectToAction("index", "Home");
                }
                var result = await _signInManager.PasswordSignInAsync(
                  model.Username , model.Password , model.RememberMe , true);
              if (result.Succeeded)
              {
                  if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                  {
                      return Redirect(returnUrl);
                  }
                  RedirectToAction("index", "Home");
              }

              if (result.IsLockedOut)
              {
                  ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل است ";
              }
              ModelState.AddModelError("","نام کاربری یا کلمه ی عبور اشتباه است");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
          await  _signInManager.SignOutAsync();
         return RedirectToAction("index", "Home");
        }

    }
}
