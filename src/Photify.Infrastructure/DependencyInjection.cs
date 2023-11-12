using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photify.Infrastructure.Configurations;
using System.Reflection;

namespace Photify.Infrastructure;

public static class DependencyInjection
{
    private static  string GetOrCreateDbFullName(IConfiguration configuration)
    {
        var configDir = configuration["CONFIG_DIR"] ?? Path.Combine(Environment.CurrentDirectory, "config");
        if (!Directory.Exists(configDir))
        {
            Directory.CreateDirectory(configDir);
        }
        var dbPath = Path.Combine(configDir, "photify.db");
        return dbPath;
    }
    public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var dbType = Enum.Parse<DatabaseProviderType>(configuration["DB_PROVIDER"] ?? "SQLite");
        var identityConnection = configuration.GetConnectionString("Identity");
        var defaultConnection = configuration.GetConnectionString("Default");
        if (dbType == DatabaseProviderType.SQLite)
        {
            services.AddSQLiteDbContents($"Data Source={GetOrCreateDbFullName(configuration)}");
        }
        else if (dbType == DatabaseProviderType.PostgreSQL)
        {
            services.AddPostgreSQLDbContents(defaultConnection, identityConnection);
        }
        return services;
    }
    private static IServiceCollection AddPostgreSQLDbContents(this IServiceCollection services, string defaultConnection, string identityConnection = null)
    {
        var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseNpgsql(identityConnection ?? defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
                sql.EnableRetryOnFailure(5);
            });
        });

        services.AddDbContext<PhotifyDbContext>(options =>
        {
            options.UseNpgsql(defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
                sql.EnableRetryOnFailure(5);
            });
        });
        return services;
    }
    private static IServiceCollection AddSQLiteDbContents(this IServiceCollection services, string defaultConnection)
    {
        var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlite(defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
            });
        });

        services.AddDbContext<PhotifyDbContext>(options =>
        {
            options.UseSqlite(defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
            });
        });
        return services;
    }
}