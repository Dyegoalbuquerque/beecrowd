using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SalesApi.Infrastructure.Persistence
{
    public class SalesDbContextFactory : IDesignTimeDbContextFactory<SalesDbContext>
    {
        public SalesDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<SalesDbContext>();
            var connectionString = configuration.GetConnectionString("SalesApiDb");

            builder.UseNpgsql(
                   connectionString,
                   b => b.MigrationsAssembly("SalesApi.Infrastructure")
            );

            return new SalesDbContext(builder.Options);
        }
    }
}
