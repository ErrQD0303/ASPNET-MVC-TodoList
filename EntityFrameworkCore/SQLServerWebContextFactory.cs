using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class WebContextFactory : IDesignTimeDbContextFactory<SQLServerWebContext>
    {
        public SQLServerWebContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SQLServerWebContext>();

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: false);

            var configRoot = configBuilder.Build();
            System.Console.WriteLine(configRoot.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseSqlServer(configRoot.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseNpgsql(configRoot["database:PostgreSQL"]);
            //optionsBuilder.AddLogging("SQLServer", "WebContext");
            //optionsBuilder.AddLogging("PostgreSQL", "WebContext");

            return new SQLServerWebContext(optionsBuilder.Options);
        }
    }
}