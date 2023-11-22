using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Texts
{
    public class UpdateTextModel : IDbModel<Text, UpdateTextModel>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = default!;
        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; } = default!;





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
