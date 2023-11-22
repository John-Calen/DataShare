using Models.Files;

namespace Business.Abstractions
{
    public interface IFileElementService : ICrudService<GetFileModel, ICreateFileModel, IUpdateFileModel, Guid>
    {
    }
}
