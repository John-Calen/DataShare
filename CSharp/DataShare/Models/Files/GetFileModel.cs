using Models.Files.Metas;
using System.Text.Json.Serialization;

namespace Models.Files
{
    public class GetFileModel
    {
        [JsonPropertyName("meta")]
        public GetFileMetaModel Meta { get; set; } = default!;
    }
}
