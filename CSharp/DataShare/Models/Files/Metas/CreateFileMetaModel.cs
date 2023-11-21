using Data.Entities;

namespace Models.Files.Metas
{
    public class CreateFileMetaModel : IDbModel<FileMeta, CreateFileMetaModel>
    {
        public required string Name { get; init; }
        public required long OwnerId { get; init; }





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
