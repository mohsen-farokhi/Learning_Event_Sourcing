namespace Framework.Domain
{
    public class EventSourceRepository<T, TKey> :
        IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        private readonly IEventStore _eventStore;
        private readonly IAggregateFactory _aggregateFactory;

        public EventSourceRepository
            (IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            _eventStore = eventStore;
            _aggregateFactory = aggregateFactory;
        }

        public async Task<T> GetById(TKey id)
        {
            var events =
                await _eventStore.GetEventsOfStream(getStreamName(id));

            return _aggregateFactory.Create<T>(events);
        }

        public async Task AppendEvents(T aggregate)
        {       
            var events =
                aggregate.GetUncommitedEvents();

            await _eventStore.Append(getStreamName(aggregate.Id), events);
        }

        private string getStreamName(TKey id)
        {
            var type = typeof(T).Name;

            return $"{type}-{id}";
        }

    }

}
