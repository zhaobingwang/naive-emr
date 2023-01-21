using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NaiveEmr.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NaiveEmr.Migrator
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=NaiveEmr.Dev;User ID=sa;Password=123456;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;", x => x.MigrationsAssembly("NaiveEmr.Migrations"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
