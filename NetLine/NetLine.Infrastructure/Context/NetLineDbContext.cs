using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetLine.Domain.Models.ProductAndCategory;
using NetLine.Domain.Models.User.Order;

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

        public DbSet<ProductToCategory> ProductToCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductToCategory>().HasKey(t => new { t.CategoryId, t.ProductId });
            modelBuilder.Entity<Item>(i =>
            {
                i.Property(w => w.Price).HasColumnType("money");
                i.HasKey(w => w.Id);
            });
            #region Seed Data Category
            modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "دسته بندی اول", Description = "این دسته بندی اول است " },
            new Category() { Id = 2, Name = "دسته بندی دوم", Description = "این دسته بندی دوم است " },
            new Category() { Id = 3, Name = "دسته بندی سوم", Description = "این دسته بندی سوم است " },
            new Category() { Id = 4, Name = "دسته بندی چهارم", Description = "این دسته بندی چهارم است " }
            );
            modelBuilder.Entity<Item>().HasData(
            new Item() { Id = 1, QuantityInStock = 5, Price = 12000 },
            new Item() { Id = 2, QuantityInStock = 4, Price = 14000 },
            new Item() { Id = 3, QuantityInStock = 6, Price = 16000 },
            new Item() { Id = 4, QuantityInStock = 7, Price = 20000 }
              );
            modelBuilder.Entity<Product>().HasData(
             new Product() { Id = 1, ItemId = 1, Name = "محصول اول", Description = "این محصول اول است" },
             new Product() { Id = 2, ItemId = 2, Name = "محصول دوم", Description = "این محصول دوم است" },
             new Product() { Id = 3, ItemId = 3, Name = "محصول سوم", Description = "این محصول سوم است " },
             new Product() { Id = 4, ItemId = 4, Name = "محصول چهارم", Description = "این محصول چهارم است " }
                );
            modelBuilder.Entity<ProductToCategory>().HasData(
               new ProductToCategory() { CategoryId = 1, ProductId =  1 },
               new ProductToCategory() { CategoryId = 2, ProductId = 2 },
               new ProductToCategory() { CategoryId = 4, ProductId = 4 },
               new ProductToCategory() { CategoryId = 3, ProductId = 3 }
                );
            #endregion
            base.OnModelCreating(modelBuilder);

        }
    }
}
