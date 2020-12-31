using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLine.Domain.ViewModels.Account.User
{
   public class LoginViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "کلمه ی عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
