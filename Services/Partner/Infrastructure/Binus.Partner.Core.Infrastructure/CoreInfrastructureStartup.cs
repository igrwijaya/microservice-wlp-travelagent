using System;
using Binus.Partner.Core.Application.Services;
using Binus.Partner.Core.Constant.Constant;
using Binus.Partner.Core.Domain.AggregateRoots.Account;
using Binus.Partner.Core.Domain.AggregateRoots.PartnerAggregate;
using Binus.Partner.Core.Domain.AggregateRoots.Post;
using Binus.Partner.Core.Infrastructure.DataSources;
using Binus.Partner.Core.Infrastructure.Models;
using Binus.Partner.Core.Infrastructure.Repositories;
using Binus.Partner.Core.Infrastructure.Repositories.Common;
using Binus.Partner.Core.Infrastructure.Repositories.Post;
using Binus.Partner.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.Partner.Core.Infrastructure
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
            services.AddScoped<IPartnerRepository, PartnerRepository>();

            #endregion

        }
    }
}