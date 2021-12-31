using FluentAssertions;
using Xunit;

namespace Framework.Domain.Test
{
    public partial class DomainEventTests
    {
        private class UserRegistered : DomainEvent
        { }

        [Fact]
        public void Each_Event_Has_Unique_Identifire()
        {
            var @event = new UserRegistered();

            @event.EventId.Should().NotBeEmpty();
        }

    }
}