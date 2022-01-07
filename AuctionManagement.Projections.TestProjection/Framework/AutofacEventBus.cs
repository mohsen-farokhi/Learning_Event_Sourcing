using Autofac;
using Framework.Domain;

namespace AuctionManagement.Projections.TestProjection.Framework
{
    public class AutofacEventBus : IEventBus
    {
        private readonly ILifetimeScope _scope;

        public AutofacEventBus(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Publish<T>(T @event) where T : DomainEvent 
        {
            var handler =
                _scope.Resolve<IEventHandler<T>>();

            handler.Handle(@event);
        }
    }
}
