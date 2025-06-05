/**
 * FeedbackService Design-Time DbContext Factory - Entity Framework Core Tooling Support
 *
 * Purpose: Factory for creating DbContext instances during Entity Framework Core design-time operations
 * Features:
 * - Design-time DbContext creation for migrations and scaffolding
 * - Configuration loading from appsettings.json files
 * - Environment-specific configuration support
 * - SQL Server database provider configuration
 *
 * Architecture: Part of the Persistence layer in clean architecture
 * - Supports Entity Framework Core design-time tooling
 * - Enables migrations without running the full application
 * - Provides configuration resolution for development environments
 * - Required for EF Core CLI tools (dotnet ef migrations, etc.)
 *
 * Usage:
 * - Used automatically by Entity Framework Core CLI tools
 * - Enables 'dotnet ef migrations add' and 'dotnet ef database update' commands
 * - Supports development workflow without application startup
 *
 * Author: Kim Hammerstad (with AI assistance from Claude 4)
 * Created: 2024 for Ventixe Event Management Platform
 */

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts;

namespace Persistence;

/// <summary>
/// Factory class for creating DataContext instances during Entity Framework Core design-time operations.
/// Implements IDesignTimeDbContextFactory to support EF Core CLI tools and migration operations.
/// Loads configuration from appsettings.json files and creates properly configured DbContext instances
/// for use by Entity Framework Core tooling without requiring the full application to run.
/// </summary>
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    /// <summary>
    /// Creates a DataContext instance for design-time operations.
    /// Loads configuration from appsettings.json files, resolves connection strings,
    /// and configures the DbContext with SQL Server provider for Entity Framework Core tooling.
    /// Used by EF Core CLI commands like migrations and database updates.
    /// </summary>
    /// <param name="args">Command-line arguments passed to the design-time factory (typically unused)</param>
    /// <returns>A configured DataContext instance ready for Entity Framework Core design-time operations</returns>
    public DataContext CreateDbContext(string[] args)
    {
        // Build configuration from appsettings.json files with environment-specific overrides
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json") // Base configuration
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
                optional: true // Environment-specific overrides
            )
            .Build();

        // Configure DbContext options with SQL Server provider
        var builder = new DbContextOptionsBuilder<DataContext>();
        var connectionString = configuration.GetConnectionString("SqlConnection");
        builder.UseSqlServer(connectionString);

        // Return configured DataContext instance for design-time operations
        return new DataContext(builder.Options);
    }
}
