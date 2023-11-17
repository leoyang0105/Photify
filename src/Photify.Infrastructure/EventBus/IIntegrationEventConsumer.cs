using MassTransit;

namespace Photify.Infrastructure.EventBus;

public interface IIntegrationEventConsumer<in TIntegrationEvent> : IConsumer<TIntegrationEvent>
     where TIntegrationEvent : IntegrationEvent
{
}
