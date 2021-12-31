using FluentAssertions;
using Xunit;

namespace Framework.Domain.Test
{
    public class AggregateRootTests
    {
        [Fact]
        public void Test()
        {
            var factory = new AggregateFactory();

            var user = factory.Create<User>
                (new System.Collections.Generic.List<DomainEvent>
                {
                    new UserRegistered(1, "Mohsen", "Farokhi", "m.farokhi"),
                    new UserActivated(1)
                });

            user.Username.Should().Be("m.farokhi");
            user.FirstName.Should().Be("Mohsen");
            user.LastName.Should().Be("Farokhi");
            user.IsActive.Should().Be(true);
        }

        [Fact]
        public void Test2() // Activate user command
        {
            // load and replay event
            var factory = new AggregateFactory();

            var user = factory.Create<User>
                (new System.Collections.Generic.List<DomainEvent>
                {
                    new UserRegistered(1, "Mohsen", "Farokhi", "m.farokhi"),
                });

            // -------- call user method

            user.Activate();

            // -------- save events into database
            var events = user.GetUncommitedEvents();
            //AppendEventsIntoEventStore(events);

        }
    }

}