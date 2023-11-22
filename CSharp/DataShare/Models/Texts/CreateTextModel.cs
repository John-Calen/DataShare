using Data.Entities;
using Models.Users;
using System.Text.Json.Serialization;

namespace Models.Texts
{
    public class CreateTextModel : IDbModel<Text, CreateTextModel>
    {
        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; } = default!;





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
