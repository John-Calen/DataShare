using Models.Texts;

namespace Business.Abstractions
{
    public interface ITextDataService : ICrudService<GetTextModel, CreateTextModel, UpdateTextModel, Guid>
    {

    }
}
