namespace Models
{
    public interface IDataModel<T_Id>
        where T_Id : notnull
    {
        public abstract T_Id Id { get; }
        public abstract DateTime CreatedAt { get; }
        public abstract long OwnerId { get; }
    }
}
