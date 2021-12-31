using System;

namespace Framework.Domain.Test
{
    public class User : AggregateRoot<long>
    {
        private User()
        {
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public bool IsActive { get; private set; }

        public override void Apply(DomainEvent @event)
        {
            when((dynamic)@event);
        }

        private void when(UserRegistered @event)
        {
            Id = @event.Id;
            FirstName = @event.FirstName;
            LastName = @event.LastName;
            Username = @event.Username;
            IsActive = false;
        }

        private void when(UserActivated @event)
        {
            IsActive = true;
        }

        private void when(UserPersonalInfoUpdated @event)
        {
            FirstName = @event.FirstName;
            LastName = @event.LastName;
        }

        public void Activate()
        {
            // check invariants 

            ApplyAndPublish(new UserActivated(Id));
        }

        public void ChangePersonalInfo(string firstName, string lastName)
        {
            if(IsActive == false)
            {
                throw new Exception("");
            }

            ApplyAndPublish(new UserPersonalInfoUpdated(firstName, lastName));
        }

        public override void ApplyAndPublish(DomainEvent @event)
        {
            _uncommitedEvents.Add(@event);
            Apply(@event);
        }
    }

}
