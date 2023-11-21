using Data.Entities;

namespace Models.Texts
{
    public class UpdateTextModel : IDbModel<Text, UpdateTextModel>
    {
        public required Guid Id { get; init; }
        public required string Content { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required long OwnerId { get; init; }





        public Text ToEntity()
        {
            return new Text
            {
                Id = Id,
                Content = Content,
                CreatedAt = CreatedAt,
                OwnerId = OwnerId
            };
        }
    }
}
