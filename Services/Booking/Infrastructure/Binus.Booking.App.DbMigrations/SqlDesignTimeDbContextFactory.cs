using System;
using System.IO;
using Binus.Booking.Core.Constant.Constant;
using Binus.Booking.Core.Infrastructure.DataSources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Binus.Booking.App.DbMigrations
{
    public class SqlDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            return CreateDbContext();
        }

        public CoreDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<CoreDbContext>();
            var dbConnection = configuration[ConfigurationConstant.ConnMysql];

            builder.UseMySql(
                dbConnection,
                new MySqlServerVersion(new Version(8, 0)),
                b => b.MigrationsAssembly(GetType().Namespace));

            return new CoreDbContext(builder.Options);
        }
    }
}