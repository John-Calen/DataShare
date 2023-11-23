using Models.Files;
using Models.Files.Metas;

namespace Business.Abstractions
{
    public interface IFileElementService : ICrudService<GetFileModel, ICreateFileModel, IUpdateFileModel, Guid>
    {
        public abstract LoadingFileModel Load(Guid id);
        public abstract GetFileMetaModel Load(Guid id, Stream to);
        public abstract Task<GetFileMetaModel> LoadAsync(Guid id, Stream to);
    }
}
