using Models.Files;

namespace Business
{
    public interface IFileElementService : ICrudService<GetFileModel, ICreateFileModel, IUpdateFileModel, Guid>
    {
    }
}
