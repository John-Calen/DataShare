namespace Data.Entities
{
    public class User: IEntity<long>
    {
        public long Id { get; set; }
        public long PrimaryKey => Id;
        public string Name { get; set; } = default!;
        public string? Password { get; set; }
    }
}
