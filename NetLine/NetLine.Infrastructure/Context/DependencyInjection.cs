using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetLine.Domain.Services.InterFaces;
using NetLine.Domain.Services.InterFaces.User.Cart;
using NetLine.Domain.Services.UnitOfWork;
using NetLine.Infrastructure.Context;
using NetLine.Infrastructure.Services.Repository.ProductAndCategory;
using NetLine.Infrastructure.Services.Repository.User.Cart;
using NetLine.Infrastructure.Services.UnitOfWork;

namespace NetLine.Infrastructure.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Db Context

            services.AddDbContext<NetLineDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext")));


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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRe, ProductRe>();
            services.AddScoped<ICartRe, CartRe>();

            #endregion

            services.AddAuthentication();

            return services;
        }
    }
}
