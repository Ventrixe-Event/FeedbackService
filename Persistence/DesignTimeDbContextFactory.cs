using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;

namespace Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
                optional: true
            )
            .Build();

        var builder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = configuration.GetConnectionString("SqlConnection");
        builder.UseSqlServer(connectionString);

        return new DataContext(builder.Options);
    }
}
