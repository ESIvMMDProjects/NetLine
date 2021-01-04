using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NetLine.Domain.Models.User.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public bool IsFinally { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
