namespace Framework.Domain
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }

        //public override bool Equals(object? obj)
        //{
        //    return base.Equals(obj);
        //}
    }
}
