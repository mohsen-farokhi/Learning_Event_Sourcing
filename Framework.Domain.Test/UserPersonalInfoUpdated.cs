namespace Framework.Domain.Test
{
    public class UserPersonalInfoUpdated : DomainEvent
    {
        public UserPersonalInfoUpdated(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }

}
