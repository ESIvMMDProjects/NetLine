using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Model.User.Order;
using NetLine.Domain.Models.User.Account;
namespace NetLine.Infrastructure.Context
{
    public class NetLineDbContext :DbContext
    {
        public NetLineDbContext(DbContextOptions<NetLineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
