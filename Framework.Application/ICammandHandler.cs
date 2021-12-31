namespace Framework.Application
{
    public interface ICammandHandler<T>
    {
        void Handle(T command);
    }
}