namespace Data.Entities
{
    public interface IPosted<T_Id>
    {
        public abstract T_Id Id { get; set; }
        public abstract User Owner { get; set; }
        public abstract long OwnerId { get; set; }
        public abstract DateTime CreatedAt { get; set; }
    }
}
