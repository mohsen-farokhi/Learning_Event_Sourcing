namespace Framework.Domain
{
    public interface IEventStore
    {
        List<DomainEvent> GetEventsOfStream(string streamId);
    }
}
