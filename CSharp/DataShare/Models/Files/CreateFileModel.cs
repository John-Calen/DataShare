using System.Text.Json.Serialization;

namespace Models.Files
{
    public class CreateFileModel : ICreateFileModel
    {
        [JsonPropertyName("file")]
        public FileInfo File { get; set; } = default!;
        [JsonPropertyName("name")]
        public string Name => File.Name;
        [JsonPropertyName("size")]
        public long Size => File.Length;
        [JsonPropertyName("ownerId")]
        public long OwnerId { get; set; }






        public Stream CreateStream()
        {
            return File.OpenRead();
        }
    }
}
