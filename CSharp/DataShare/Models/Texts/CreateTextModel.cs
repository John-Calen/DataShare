using Data.Entities;
using Models.Users;

namespace Models.Texts
{
    public class CreateTextModel : IDbModel<Text, CreateTextModel>
    {
        public required string Content { get; init; }
        public required long OwnerId { get; init; }





        public Text ToEntity()
        {
            return new Text
            {
                Content = Content,
                CreatedAt = DateTime.UtcNow,
                OwnerId = OwnerId
            };
        }
    }
}
