namespace Data.Entities
{
    public interface IEntity<T_PrimaryKey>
    {
        public abstract T_PrimaryKey PrimaryKey { get; }
    }
}
