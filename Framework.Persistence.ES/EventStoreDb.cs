using EventStore.ClientAPI;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public class EventStoreDb : IEventStore
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreDb(IEventStoreConnection connection)
        {
            _connection = connection;
        }

        public async Task Append(string streamId, IEnumerable<DomainEvent> events)
        {
            var eventData =
                EventDataFactory.CreateFromDomainEvents(events);

            await _connection.AppendToStreamAsync
                (streamId, ExpectedVersion.Any, eventData);
        }

        public async Task<List<DomainEvent>> GetEventsOfStream
            (string streamId)
        {
            var streamEvents = await EventStreamReader.Read
                (_connection,streamId,StreamPosition.Start,200);

            return DomainEventFactory.Create(streamEvents);
        }
    }

}