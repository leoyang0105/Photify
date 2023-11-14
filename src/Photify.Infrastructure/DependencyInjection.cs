using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Photify.Infrastructure;

public static class DependencyInjection
{
    private static string GetOrCreateDbFullName(IConfiguration configuration)
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
        var provider = configuration["DB_PROVIDER"] ?? "SQLite";
        _ = provider switch
        {
            "SQLite" => services.AddSQLiteDbContents($"Data Source={GetOrCreateDbFullName(configuration)}"),
            "PostgreSQL" => services.AddPostgreSQLDbContents(configuration.GetConnectionString("Default"), configuration.GetConnectionString("Identity")),
            _ => throw new Exception($"Unsupported provider: {provider}")
        };

        return services;
    }
    private static IServiceCollection AddPostgreSQLDbContents(this IServiceCollection services, string defaultConnection, string identityConnection = null)
    {
        var migrationsAssembly = "Photify.Migrations.PostgreSQL";

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseNpgsql(identityConnection ?? defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
                sql.EnableRetryOnFailure(5);
            });
        });

        services.AddDbContext<PhotifyContext>(options =>
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
        var migrationsAssembly = "Photify.Migrations.SQLite";

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlite(defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
            });
        });

        services.AddDbContext<PhotifyContext>(options =>
        {
            options.UseSqlite(defaultConnection, sql =>
            {
                sql.MigrationsAssembly(migrationsAssembly);
            });
        });
        return services;
    }
}