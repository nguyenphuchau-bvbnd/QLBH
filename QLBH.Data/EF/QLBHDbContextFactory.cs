using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QLBH.Data.EF
{
    public class QLBHDbContextFactory : IDesignTimeDbContextFactory<QLBHDbContext>
    {
        public QLBHDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("QLBHDb");

            var optionsBuilder = new DbContextOptionsBuilder<QLBHDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QLBHDbContext(optionsBuilder.Options);
        }
    }
}
