namespace Data.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Password { get; set; }
    }
}
