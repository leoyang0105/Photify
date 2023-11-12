using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Photify.Infrastructure;
using System.Reflection;

namespace Photify.EntityFramework.PostgreSQL;

public static class DependencyInjection
{
    public static IServiceCollection AddPostgreSQLDbContents(this IServiceCollection services, string defaultConnection, string identityConnection = null)
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
}