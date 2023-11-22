using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Files.Metas
{
    public class UpdateFileMetaModel : IDbModel<FileMeta, UpdateFileMetaModel>
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = default!;
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("size")]
        public long Size { get; set; } = default!;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; } = default!;





        public FileMeta ToEntity()
        {
            return new FileMeta
            {
                Id = Id,
                Name = Name,
                Size = Size,
                CreatedAt = CreatedAt,
                OwnerId = OwnerId
            };
        }
    }
}
