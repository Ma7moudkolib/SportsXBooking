using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.DatabaseContext
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var dbServer = Environment.GetEnvironmentVariable("DB_SERVER") ?? "127.0.0.1,1433";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "SportsBookingDB";
            var dbUser = Environment.GetEnvironmentVariable("DB_USER") ?? "sa";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "YourStrong@Password123";

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(
                $"Server={dbServer};Database={dbName};User Id={dbUser};Password={dbPassword};Encrypt=false;TrustServerCertificate=true;");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
