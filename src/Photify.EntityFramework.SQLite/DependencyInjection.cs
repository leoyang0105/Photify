using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Photify.Infrastructure;
using System.Reflection;

namespace Photify.EntityFramework.SQLite;

public static class DependencyInjection
{
    public static IServiceCollection AddSQLiteDbContents(this IServiceCollection services, string defaultConnection, string identityConnection = null)
    {
        var migrationsAssembly = typeof(DependencyInjection).GetTypeInfo().Assembly.GetName().Name;

        services.AddDbContext<IdentityContext>(options =>
        {
            options.UseSqlite(identityConnection ?? defaultConnection, sql =>
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