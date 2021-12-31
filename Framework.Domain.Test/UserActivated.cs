namespace Framework.Domain.Test
{
    public class UserActivated : DomainEvent
    {
        public UserActivated(long userId)
        {
            UserId = userId;
        }
        public long UserId { get; private set; }
    }

}
