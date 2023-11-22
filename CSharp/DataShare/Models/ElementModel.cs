using Models.Files;
using Models.Texts;
using System.Text.Json.Serialization;

namespace Models
{
    public class ElementModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; } = default!;
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; } = default!;
        [JsonPropertyName("content")]
        public string Content { get; set; } = default!;
        [JsonPropertyName("elementType")]
        public ElementType ElementType { get; set; } = default!;





        public static ElementModel? FromText(GetTextModel? model)
        {
            if (model is null)
                return null;

            return new ElementModel
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                Content = model.Content,
                ElementType = ElementType.TEXT
            };
        }

        public static ElementModel? FromFile(GetFileModel? model)
        {
            if (model is null)
                return null;

            return new ElementModel
            {
                Id = model.Meta.Id,
                CreatedAt = model.Meta.CreatedAt,
                Content = model.Meta.Name,
                ElementType = ElementType.FILE
            };
        }
    }
}
