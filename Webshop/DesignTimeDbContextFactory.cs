using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebshopData;

namespace Webshop
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebshopContext>
    {
        public WebshopContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var builder = new DbContextOptionsBuilder<WebshopContext>();

            var connectionString = configuration.GetConnectionString("WebshopConnection");

            builder.UseSqlServer(connectionString);

            return new WebshopContext(builder.Options);
        }
    }
}
