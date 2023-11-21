using Data.Entities;

namespace Models.Texts
{
    public class GetTextModel : IGetDbEntiyModel<Text, GetTextModel>
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

        public static GetTextModel ToModel(Text element)
        {
            return new GetTextModel
            {
                Id = element.Id,
                Content = element.Content,
                CreatedAt = element.CreatedAt,
                OwnerId = element.OwnerId
            };
        }
    }
}
