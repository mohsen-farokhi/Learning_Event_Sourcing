namespace Framework.Application
{
    public interface ICammandHandler<T>
    {
        Task Handle(T command);
    }
}