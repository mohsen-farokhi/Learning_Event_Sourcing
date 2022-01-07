using AuctionManagement.Application;
using AuctionManagement.Domain.Models.Auctions;
using AuctionManagement.Persistance.ES;
using Autofac;
using EventStore.ClientAPI;
using Framework.Application;
using Framework.Domain;
using Framework.Persistence.ES;

namespace AuctionManagement.Config;
public class AuctionModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder
            .Register(CreateEventStoreConnection)
            .SingleInstance();

        builder
            .RegisterType<EventStoreDb>()
            .As<IEventStore>()
            .SingleInstance();

        builder
            .RegisterType<AutofacCommandBus>()
            .As<ICommandBus>()
            .SingleInstance();

        builder
            .RegisterType<AggregateFactory>()
            .As<IAggregateFactory>()
            .SingleInstance();

        builder
            .RegisterGeneric(typeof(EventSourceRepository<,>))
            .As(typeof(IEventSourceRepository<,>))
            .SingleInstance();

        builder
            .RegisterType<AuctionRepository>()
            .As<IAuctionRepository>()
            .SingleInstance();

        builder
            .RegisterAssemblyTypes(typeof(AuctionCommandHandlers).Assembly)
            .As(type => type.GetInterfaces()
                .Where(t => t.IsClosedTypeOf(typeof(ICammandHandler<>))))
            .InstancePerLifetimeScope();
    }

    public static IEventStoreConnection CreateEventStoreConnection
        (IComponentContext context)
    {
        var setting =
            ConnectionSettings.Create()
            .SetHeartbeatInterval(TimeSpan.FromSeconds(10))
            .SetHeartbeatTimeout(TimeSpan.FromMinutes(5))
            .Build();

        var connection =
            EventStoreConnection.Create
            (setting, new Uri("tcp://admin:changeit@localhost:1113"));

        connection.ConnectAsync().Wait();

        return connection;
    }
}