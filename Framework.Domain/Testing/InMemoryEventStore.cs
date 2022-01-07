namespace Framework.Domain.Testing
{
    public class InMemoryEventStore : IEventStore
    {
        private Dictionary<string, List<DomainEvent>> _events =
            new Dictionary<string, List<DomainEvent>>();

        public Task Append(string streamId, IEnumerable<DomainEvent> events)
        {
            if (_events.ContainsKey(streamId))
            {
                _events[streamId].AddRange(events);
            }
            else
            {
                _events.Add(streamId, events.ToList());
            }

            return Task.CompletedTask;
        }

        public Task<List<DomainEvent>> GetEventsOfStream(string streamId)
        {
            return Task.FromResult(_events[streamId]);
        }
    }
}
