using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Text: IPosted<Guid>
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public User Owner { get; set; } = default!;
        [ForeignKey(nameof(Owner))]
        public long OwnerId { get; set; }
    }
}
