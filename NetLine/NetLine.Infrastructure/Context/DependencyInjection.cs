using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetLine.Infrastructure.Context;

namespace Eshop.Infrastructure.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Db Context

            services.AddDbContext<NetLineDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            #endregion

            #region Identity

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                })
                .AddEntityFrameworkStores<NetLineDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            #region IoC

            /*services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IManageAccountRepository, ManageAccountRepository>();*/

            #endregion

            services.AddAuthentication();

            return services;
        }
    }
}
