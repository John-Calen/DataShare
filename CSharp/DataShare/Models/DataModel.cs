using Models.Files;
using Models.Files.Metas;
using Models.Texts;
using System.Text.Json.Serialization;

namespace Models
{
    public class DataModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = default!;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;
        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;
        [JsonPropertyName("dataType")]
        public DataType DataType { get; set; } = default!;





        public static DataModel? FromText(GetTextModel? model)
        {
            if (model is null)
                return null;

            return new DataModel
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                Content = model.Content,
                DataType = DataType.TEXT
            };
        }

        public static DataModel? FromFile(GetFileMetaModel? model)
        {
            if (model is null)
                return null;

            return new DataModel
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                Content = model.Name,
                DataType = DataType.FILE
            };
        }
    }
}
