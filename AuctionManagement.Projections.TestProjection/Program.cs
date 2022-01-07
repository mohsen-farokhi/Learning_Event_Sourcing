using AuctionManagement.Domain.Contracts.Auctions.Events;
using AuctionManagement.Projections.TestProjection;
using AuctionManagement.Projections.TestProjection.Framework;
using Autofac;
using EventStore.ClientAPI;
using Framework.Persistence.ES;
using Newtonsoft.Json;
using System.Text;

var containerBuilder = new ContainerBuilder();
containerBuilder.RegisterModule<TestProjectionModule>();

var container = containerBuilder.Build(); 

IEventTypeResolver _typeResolver;

_typeResolver = new EventTypeResolver();
_typeResolver.AddTypeFromAssembly(typeof(BidPlaced).Assembly);

var connection = EventStoreConnection.Create
    (new Uri("tcp://admin:changeit@localhost:1113"));

connection.ConnectAsync().Wait();

connection.SubscribeToAllFrom
(Position.Start,
CatchUpSubscriptionSettings.Default,
EventAppeared,
LiveProcessingStarted,
SubscriptionDropped);

Console.WriteLine("Subscribed!");

Console.ReadLine();

void SubscriptionDropped
    (EventStoreCatchUpSubscription arg1, SubscriptionDropReason arg2, Exception arg3)
{
    Console.WriteLine("Subscription Dropped!");
    Console.WriteLine("-----------------");
}

void LiveProcessingStarted
    (EventStoreCatchUpSubscription obj)
{
    Console.WriteLine("Live Processing Started!");
    Console.WriteLine("-----------------");
}

Task EventAppeared
    (EventStoreCatchUpSubscription arg1, ResolvedEvent arg2)
{
    var typeOfEvent = _typeResolver.GetType(arg2.Event.EventType);
    
    if (typeOfEvent != null)
    {
        var body = Encoding.UTF8.GetString(arg2.Event.Data);
        var domainEvent = JsonConvert.DeserializeObject(body, typeOfEvent);

        IEventBus bus = container.Resolve<IEventBus>(); 
        bus.Publish((dynamic)domainEvent);


        //Console.WriteLine("Event Appeared!");
        //Console.WriteLine($"Type ===> {arg2.Event.EventType}");
        //Console.WriteLine(Encoding.UTF8.GetString(arg2.Event.Data));
        //Console.WriteLine("-----------------");
    }

    return Task.CompletedTask;
}
