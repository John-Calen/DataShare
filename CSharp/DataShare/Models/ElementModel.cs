using Models.Files;
using Models.Texts;

namespace Models
{
    public class ElementModel
    {
        public required Guid Id { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required string Content { get; init; }
        public required ElementType ElementType { get; init; }





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
