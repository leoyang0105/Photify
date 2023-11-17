using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photify.Application.Interfaces;

namespace Photify.FileProvider;

public static class DependencyInjection
{
    public static IServiceCollection AddFileProviders(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileProviderFactory, FileProviderFactory>();
        services.AddSingleton<LocalFileProvider>();
        return services;
    }
}
