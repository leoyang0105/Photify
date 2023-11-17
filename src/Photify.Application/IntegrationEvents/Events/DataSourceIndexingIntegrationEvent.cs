using Photify.Infrastructure.EventBus;

namespace Photify.Application.IntegrationEvents.Events;

public record DataSourceIndexingIntegrationEvent : IntegrationEvent
{
    public int DataSourceId { get; set; }
    public DataSourceIndexingIntegrationEvent(int dataSourceId)
    {
        DataSourceId = dataSourceId;
    }
}
