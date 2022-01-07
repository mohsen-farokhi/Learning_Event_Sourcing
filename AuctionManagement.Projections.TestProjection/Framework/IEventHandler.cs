using Framework.Domain;

namespace AuctionManagement.Projections.TestProjection.Framework
{

    internal interface IEventHandler<T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }
}
