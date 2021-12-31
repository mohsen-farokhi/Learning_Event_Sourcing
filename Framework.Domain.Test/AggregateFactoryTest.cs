using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Framework.Domain.Test
{
    public class AggregateFactoryTest
    {
        [Fact]
        public void Create_Aggregate_By_Applying_Events()
        {
            var events = new List<DomainEvent>
            {
                new UserRegistered(1,"Mohsen","Farokhi","m.farokhi"),
                new UserActivated(1),
                new UserPersonalInfoUpdated("John","Farokhi"),
            };

            var factory = new AggregateFactory();

            var user = factory.Create<User>(events);

            user.IsActive.Should().BeTrue();
            user.FirstName.Should().Be("John");
            user.LastName.Should().Be("Farokhi");
            user.Username.Should().Be("m.farokhi");
        }
    }

}
