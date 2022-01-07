using EventStore.ClientAPI;
using Framework.Domain;
using Newtonsoft.Json;
using System.Text;

namespace Framework.Persistence.ES
{
    internal class EventDataFactory
    {
        public static EventData CreateFromDomainEvent
            (DomainEvent domainEvent)
        {
            var data = JsonConvert.SerializeObject(domainEvent);

            var eventPayload = new EventData
                (eventId: domainEvent.EventId,
                 type: domainEvent.GetType().Name,
                 isJson: true,
                 data: Encoding.UTF8.GetBytes(data),
                 metadata: new byte[] { });

            return eventPayload;
        }

        public static IList<EventData> CreateFromDomainEvents
            (IEnumerable<DomainEvent> domainEvents) =>
                domainEvents.Select(CreateFromDomainEvent).ToList();
    }
}