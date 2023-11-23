namespace Data.Entities
{
    public interface IPosted<T_PrimaryKey>: IEntity<T_PrimaryKey>
    {
        public abstract T_PrimaryKey Id { get; set; }
        public abstract User Owner { get; set; }
        public abstract long OwnerId { get; set; }
        public abstract DateTime CreatedAt { get; set; }
    }
}
