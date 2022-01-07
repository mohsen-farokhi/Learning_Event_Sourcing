using EventStore.ClientAPI;
using Framework.Domain;
using Newtonsoft.Json;
using System.Text;

namespace Framework.Persistence.ES
{
    internal class DomainEventFactory
    {
        public static List<DomainEvent> Create(IList<ResolvedEvent> events)
        {
            return 
                events.Select(Create).ToList();
        }

        public static DomainEvent Create(ResolvedEvent @event)
        {
            var type = @event.Event.EventType;

            var body = Encoding.UTF8.GetString(@event.Event.Data);

            //JsonConvert.DeserializeObject(body,)
            return null;
        }
    }
}