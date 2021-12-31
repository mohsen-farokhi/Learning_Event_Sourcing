using System.Reflection;

namespace Framework.Domain
{
    public class AggregateFactory : IAggregateFactory
    {
        public T Create<T>(List<DomainEvent> events) where T : IAggregateRoot
        {
            var aggregate =
                (T)Activator.CreateInstance(type: typeof(T), nonPublic: true);
             
            foreach (var @event in events)
            {
                aggregate.Apply(@event);
            }

            return aggregate;
        }
    }

}
