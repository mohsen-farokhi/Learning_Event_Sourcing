namespace Framework.Domain
{
    public class EventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        private readonly IEventStore _eventStore;
        private readonly IAggregateFactory _aggregateFactory;

        public EventSourceRepository
            (IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            _eventStore = eventStore;
            _aggregateFactory = aggregateFactory;
        }

        public T GetById(TKey id)
        {
            var events =
                _eventStore.GetEventsOfStream(getStreamName(id));

            return _aggregateFactory.Create<T>(events);
        }

        private string getStreamName(TKey id)
        {
            var type = typeof(T).Name;

            return $"{type}-{id}";
        }

    }

}
