namespace Framework.Domain
{
    public interface IEventStore
    {
        Task<List<DomainEvent>> GetEventsOfStream(string streamId);
        Task Append(string streamId, IEnumerable<DomainEvent> events);
    }
}
