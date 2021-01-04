using NetLine.Domain.Models.User.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLine.Domain.Models.ProductAndCategory
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public ICollection<ProductToCategory> CategoryToProducts { get; set; }
        public Item Item { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}
