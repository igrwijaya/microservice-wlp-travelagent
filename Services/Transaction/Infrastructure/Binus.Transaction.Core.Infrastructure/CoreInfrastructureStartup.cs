using System;
using Binus.Transaction.Core.Application.Services;
using Binus.Transaction.Core.Constant.Constant;
using Binus.Transaction.Core.Domain.AggregateRoots.Account;
using Binus.Transaction.Core.Domain.AggregateRoots.Post;
using Binus.Transaction.Core.Domain.AggregateRoots.TransactionAggregate;
using Binus.Transaction.Core.Infrastructure.DataSources;
using Binus.Transaction.Core.Infrastructure.Models;
using Binus.Transaction.Core.Infrastructure.Repositories;
using Binus.Transaction.Core.Infrastructure.Repositories.Common;
using Binus.Transaction.Core.Infrastructure.Repositories.Post;
using Binus.Transaction.Core.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Binus.Transaction.Core.Infrastructure
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
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            #endregion

        }
    }
}