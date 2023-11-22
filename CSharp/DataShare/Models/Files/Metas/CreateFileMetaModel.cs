using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Files.Metas
{
    public class CreateFileMetaModel : IDbModel<FileMeta, CreateFileMetaModel>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; }





        public FileMeta ToEntity()
        {
            return new FileMeta
            {
                Name = Name,
                Size = 0,
                CreatedAt = DateTime.UtcNow,
                OwnerId = OwnerId
            };
        }
    }
}
