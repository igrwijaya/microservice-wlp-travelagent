using System;
using Binus.Flight.Core.Application.Services;
using Binus.Flight.Core.Constant.Constant;
using Binus.Flight.Core.Domain.AggregateRoots.Account;
using Binus.Flight.Core.Domain.AggregateRoots.FlightPassengerAggregate;
using Binus.Flight.Core.Domain.AggregateRoots.FlightSearchAggregate;
using Binus.Flight.Core.Domain.AggregateRoots.Post;
using Binus.Flight.Core.Infrastructure.DataSources;
using Binus.Flight.Core.Infrastructure.Models;
using Binus.Flight.Core.Infrastructure.Repositories;
using Binus.Flight.Core.Infrastructure.Repositories.Common;
using Binus.Flight.Core.Infrastructure.Repositories.Post;
using Binus.Flight.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.Flight.Core.Infrastructure
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

            #endregion

            #region Repositories

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IFlightPassengerRepository, FlightPassengerRepository>();
            services.AddScoped<IFlightSearchRepository, FlightSearchRepository>();

            #endregion

        }
    }
}