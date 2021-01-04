using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLine.Domain.Model.User.Order;

namespace NetLine.Domain.Models.User.Account
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
        [Required]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "کلمه ی عبور")]
        public string Password { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public bool RememberMe { get; set; }

        public List<Order> Orders { get; set; }
    }
}
