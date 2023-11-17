using MassTransit;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photify.Infrastructure.Cache;
using StackExchange.Redis;
using Photify.Infrastructure;
using Photify.Application.Services;
using Photify.Application.IntegrationEvents.EventHandling;
using Photify.Application.Queries;
using Photify.Application.Interfaces;
using Photify.FileProcessor;
using Photify.Application.Services.FileProcessor;

namespace Photify.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration);
            services.AddCaching(configuration);
            services.AddEventBus(configuration);

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            });
            services.AddScoped<IDataSourceQueries, DataSourceQueries>();
            services.AddScoped<IFileObjectQueries, FileObjectQueries>();
            services.AddScoped<IContentQueries, ContentQueries>();

            services.AddScoped<IDataSourceService, DataSourceService>();
            services.AddScoped<ILocalFileService, ILocalFileService>();
            return services;
        }
        public static IServiceCollection AddFileProcessors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFileProcessorFactory, FileProcessorFactory>();
            services.AddSingleton<ImageProcessor>();
            services.AddSingleton<VideoProcessor>();
            services.AddSingleton<UnsupportedFileProcessor>();

            services.AddSingleton<IThumbnailGeneratorFactory, ThumbnailGeneratorFactory>();
            services.AddSingleton<ImageThumbnailGenerator>();
            services.AddSingleton<VideoThumbnailGenerator>();
            services.AddSingleton<DefaultThumbnailGenerator>();
            return services;
        }
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var consumerAssembily = typeof(DependencyInjection).Assembly;
            var eventBusSection = configuration.GetSection("EventBus");
            if (string.IsNullOrEmpty(eventBusSection.Value))
            {
                services.AddMassTransit(s =>
                {
                    s.AddConsumer<DataSourceIndexingIntegrationEventConsumer>();
                    s.UsingInMemory((ctx, cfg) =>
                    {
                        cfg.ConfigureEndpoints(ctx);
                    });
                });
            }
            else
            {
                services.AddMassTransit(config =>
                {
                    config.AddConsumers(consumerAssembily);
                    config.UsingRabbitMq((context, mq) =>
                    {
                        mq.Host(eventBusSection["HostName"], eventBusSection["VirtualHost"], h =>
                        {
                            h.Username(eventBusSection["Username"]);
                            h.Password(eventBusSection["Password"]);
                        });
                        mq.ConfigureEndpoints(context);
                    });
                });
            }
            return services;
        }
        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnection = configuration.GetConnectionString("Redis");
            int.TryParse(configuration["DefaultCacheMinutes"] ?? "30", out var defaultCacheTimeMinutes);

            if (string.IsNullOrEmpty(redisConnection))
            {
                services.AddMemoryCache();
                services.AddSingleton<ICacheManager>(s => new MemoryCacheManager(s.GetRequiredService<IMemoryCache>(), defaultCacheTimeMinutes));
            }
            else
            {
                services.AddSingleton(sp =>
                {
                    var configuration = ConfigurationOptions.Parse(redisConnection, true);
                    configuration.ResolveDns = true;
                    return ConnectionMultiplexer.Connect(configuration);
                });

                services.AddSingleton<ICacheManager>(s => new RedisCacheManager(s.GetRequiredService<ConnectionMultiplexer>(), defaultCacheTimeMinutes));
            }
            return services;
        }

    }
}
