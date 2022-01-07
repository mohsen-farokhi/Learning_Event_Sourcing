using Framework.Domain;

namespace AuctionManagement.Projections.TestProjection.Framework
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : DomainEvent;
    }
}
