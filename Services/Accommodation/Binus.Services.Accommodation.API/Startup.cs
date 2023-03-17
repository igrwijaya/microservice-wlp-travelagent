using System;
using System.IO;
using System.Text;
using Binus.Accommodation.Core.Application;
using Binus.Accommodation.Core.Application.Command;
using Binus.Accommodation.Core.Application.Services;
using Binus.Accommodation.Core.Constant.Constant;
using Binus.Accommodation.Core.Infrastructure;
using Binus.Accommodation.Core.Infrastructure.DataSources;
using Binus.Services.Accommodation.API.Infrastructures;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Design;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Design.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

namespace Binus.Services.Accommodation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCoreApp();
            services.AddCoreAppDomain();
            services.AddCoreInfrastructure(Configuration, GetType().Namespace);
            services.AddSingleton<ISessionUserService, SessionUserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Binus.Services.Accommodation.API", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            
            // Adding Authentication  
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidAudience = Configuration[ConfigurationConstant.JwtAudience],
                        ValidIssuer = Configuration[ConfigurationConstant.JwtIssuer],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[ConfigurationConstant.JwtKey]))
                    };
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var dbContextFactory = new SqlDesignTimeDbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext();

            dbContext.Database.EnsureCreated();
            dbContext.Database.Migrate();

            var result = dbContext.ScaffoldMigration($"TestName-{Guid.NewGuid().ToString("N").Substring(0, 10)}", GetType().Namespace);
            
            var migrationId = result.MigrationId;
            var efVersion = Microsoft.EntityFrameworkCore.Infrastructure.ProductInfo.GetVersion();
            
            // Don't need to run DB Migration here. ScaffoldMigration already migrated it, just save the migration version
            dbContext.Database.ExecuteSqlRaw($"INSERT INTO __EFMigrationsHistory VALUES ('{migrationId}', '{efVersion}');");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Binus.Services.Accommodation.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseMiddleware<AppAuthorizationMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }

    public static class DbContextExtensions
    {
        private const string SubNamespace = "Migrations";

        public static ScaffoldedMigration ScaffoldMigration(this DbContext context, string migrationName,
            string rootNamespace)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (migrationName == null)
            {
                throw new ArgumentNullException(nameof(migrationName));
            }

            if (rootNamespace == null)
            {
                throw new ArgumentNullException(nameof(rootNamespace));
            }

            var logger = context.GetService<ILoggerFactory>()
                .CreateLogger($"{rootNamespace}.{SubNamespace}");

            var reporter = new OperationReporter(
                new OperationReportHandler(
                    m => logger.LogError(m),
                    m => logger.LogWarning(m),
                    m => logger.LogInformation(m),
                    m => logger.LogTrace(m)));

            var designTimeServices = new ServiceCollection()
                .AddSingleton(context.GetService<IHistoryRepository>())
                .AddSingleton(context.GetService<IMigrationsIdGenerator>())
                .AddSingleton(context.GetService<IMigrationsModelDiffer>())
                .AddSingleton(context.GetService<IMigrationsAssembly>())
                .AddSingleton(context.GetService<IDesignTimeModel>().Model)
                .AddSingleton(context.GetService<ICurrentDbContext>())
                .AddSingleton(context.GetService<IDatabaseProvider>())
                .AddSingleton(context.GetService<IMigrator>())
                .AddSingleton(context.GetService<IRelationalTypeMappingSource>())
                .AddSingleton<IMigrationsCodeGeneratorSelector, MigrationsCodeGeneratorSelector>()
                .AddSingleton<MigrationsCodeGeneratorDependencies>()
                .AddSingleton<ICSharpHelper, CSharpHelper>()
                .AddSingleton<CSharpMigrationOperationGeneratorDependencies>()
                .AddSingleton<ICSharpMigrationOperationGenerator, CSharpMigrationOperationGenerator>()
                .AddSingleton<CSharpSnapshotGeneratorDependencies>()
                .AddSingleton<ICSharpSnapshotGenerator, CSharpSnapshotGenerator>()
                .AddSingleton<CSharpMigrationsGeneratorDependencies>()
                .AddSingleton<IMigrationsCodeGenerator, CSharpMigrationsGenerator>()
                .AddSingleton<IOperationReporter>(reporter)
                .AddSingleton<MigrationsScaffolderDependencies>()
                .AddSingleton<MigrationsScaffolder>()
                .AddSingleton<ISnapshotModelProcessor, SnapshotModelProcessor>()
                .AddSingleton<AnnotationCodeGeneratorDependencies>()
                .AddSingleton<IAnnotationCodeGenerator, MySqlAnnotationCodeGenerator>()
                .AddSingleton<TypeMappingSourceDependencies>()
                .AddSingleton<ITypeMappingSource, MySqlTypeMappingSource>()
                .AddEntityFrameworkMySql()
                .AddSingleton<IValueConverterSelector, ValueConverterSelector>()
                .BuildServiceProvider();

            var scaffolder = designTimeServices.GetRequiredService<MigrationsScaffolder>();
            var result = scaffolder.ScaffoldMigration(migrationName, rootNamespace, SubNamespace);
            scaffolder.Save(Directory.GetCurrentDirectory(), result, Directory.CreateDirectory("Migrations").Name);

            return result;
        }
    }
}