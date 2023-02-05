using System;
using Binus.Deals.Core.Application.Services;
using Binus.Deals.Core.Constant.Constant;
using Binus.Deals.Core.Domain.AggregateRoots.DealsAggregate;
using Binus.Deals.Core.Domain.AggregateRoots.DealsComponentAggregate;
using Binus.Deals.Core.Infrastructure.DataSources;
using Binus.Deals.Core.Infrastructure.Models;
using Binus.Deals.Core.Infrastructure.Repositories;
using Binus.Deals.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.Deals.Core.Infrastructure
{
    public static class CoreInfrastructureStartup
    {
        public static void AddCoreInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CoreDbContext>(    
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        configuration[ConfigurationConstant.ConnMysql],
                        new MySqlServerVersion(new Version(8, 0)))
            );
            
            services.AddIdentity<AppUserIdentity, IdentityRole>(options => 
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<CoreDbContext>()
                .AddDefaultTokenProviders();

            #region Service

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IQueueService, QueueService>();

            #endregion

            #region Repositories

            services.AddScoped<IDealsRepository, DealsRepository>();
            services.AddScoped<IDealsComponentRepository, DealsComponentRepository>();

            #endregion

        }
    }
}