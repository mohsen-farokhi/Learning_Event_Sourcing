namespace Framework.Domain.Test
{
    public class UserRegistered : DomainEvent
    {
        public UserRegistered
            (long id,string firstName,string lastName,string username)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }

        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
    }

}
