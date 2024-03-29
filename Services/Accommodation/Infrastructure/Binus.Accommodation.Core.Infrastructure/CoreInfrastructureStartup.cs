using System;
using Binus.Accommodation.Core.Application.Services;
using Binus.Accommodation.Core.Constant.Constant;
using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationBookingCodeAggregate;
using Binus.Accommodation.Core.Domain.AggregateRoots.AccommodationSearchAggregate;
using Binus.Accommodation.Core.Infrastructure.DataSources;
using Binus.Accommodation.Core.Infrastructure.Models;
using Binus.Accommodation.Core.Infrastructure.Repositories;
using Binus.Accommodation.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.Accommodation.Core.Infrastructure
{
    public static class CoreInfrastructureStartup
    {
        public static void AddCoreInfrastructure(this IServiceCollection services, IConfiguration configuration, string migrationNamespace)
        {
            services.AddDbContext<CoreDbContext>(    
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        configuration[ConfigurationConstant.ConnMysql],
                        new MySqlServerVersion(new Version(8, 0)),b => b.MigrationsAssembly(migrationNamespace))
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

            services.AddScoped<IAccommodationSearchRepository, AccommodationSearchRepository>();
            services.AddScoped<IAccommodationBookingCodeRepository, AccommodationBookingCodeRepository>();

            #endregion

        }
    }
}