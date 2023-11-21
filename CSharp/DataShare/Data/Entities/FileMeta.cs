using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class FileMeta: IPosted<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public long Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Owner { get; set; } = default!;
        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
    }
}
