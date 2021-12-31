namespace Framework.Domain;

public interface IAggregateRoot
{
    void Apply(DomainEvent @event);
}

public abstract class AggregateRoot<T> : Entity<T> , IAggregateRoot
{
    protected List<DomainEvent> _uncommitedEvents { get; set; } =
        new List<DomainEvent>();

    public IReadOnlyCollection<DomainEvent> GetUncommitedEvents() => 
        _uncommitedEvents.AsReadOnly();

    public abstract void ApplyAndPublish(DomainEvent @event);

    public abstract void Apply(DomainEvent @event);
}
