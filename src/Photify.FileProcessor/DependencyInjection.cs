using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photify.Application.Interfaces;

namespace Photify.FileProcessor;

public static class DependencyInjection
{
    public static IServiceCollection AddFileProcessors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFileProcessorFactory, FileProcessorFactory>();
        services.AddSingleton<ImageProcessor>();
        services.AddSingleton<VideoProcessor>();
        services.AddSingleton<UnsupportedFileProcessor>();
        return services;
    }
}
