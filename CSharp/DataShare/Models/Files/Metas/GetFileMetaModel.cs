using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Files.Metas
{
    public class GetFileMetaModel : IGetDbEntiyModel<FileMeta, GetFileMetaModel>
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

        public static GetFileMetaModel ToModel(FileMeta element)
        {
            return new GetFileMetaModel
            {
                Id = element.Id,
                Name = element.Name,
                Size = element.Size,
                CreatedAt = element.CreatedAt,
                OwnerId = element.OwnerId
            };
        }
    }
}
