using AuctionManagement.Projections.TestProjection.Framework;
using AuctionManagement.Projections.TestProjection.Handlers;
using AuctionManagement.Query.Model;
using Autofac;

namespace AuctionManagement.Projections.TestProjection
{
    public class TestProjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(BidPlacedHandler).Assembly)
                .As(type => type.GetInterfaces()
                    .Where(t => t.IsClosedTypeOf(typeof(IEventHandler<>))))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<AutofacEventBus>()
                .As<IEventBus>();

            builder
                .RegisterType<AuctionDbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
