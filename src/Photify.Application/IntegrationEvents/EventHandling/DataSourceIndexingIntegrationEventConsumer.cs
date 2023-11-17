using MassTransit;
using Microsoft.Extensions.Logging;
using Photify.Application.IntegrationEvents.Events;
using Photify.Application.Services;
using Photify.Infrastructure.EventBus;

namespace Photify.Application.IntegrationEvents.EventHandling
{
    public class DataSourceIndexingIntegrationEventConsumer : IIntegrationEventConsumer<DataSourceIndexingIntegrationEvent>
    {
        private readonly ILogger _logger;
        private readonly IDataSourceService _dataSourceService;
        public DataSourceIndexingIntegrationEventConsumer(ILogger<DataSourceIndexingIntegrationEventConsumer> logger,
            IDataSourceService dataSourceService)
        {
            _logger = logger;
            _dataSourceService = dataSourceService;
        }

        public async Task Consume(ConsumeContext<DataSourceIndexingIntegrationEvent> context)
        {
            try
            {
                await _dataSourceService.Indexing(context.Message.DataSourceId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Indexing Failed.");
            }
        }
    }
}
