using Data.Entities;

namespace Models.Files.Metas
{
    public class UpdateFileMetaModel : IDbModel<FileMeta, UpdateFileMetaModel>
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
        public required long Size { get; init; }
        public required DateTime CreatedAt { get; init; }
        public required long OwnerId { get; init; }





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
