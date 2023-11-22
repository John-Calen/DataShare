using Models.Texts;

namespace Business.Abstractions
{
    public interface ITextElementService : ICrudService<GetTextModel, CreateTextModel, UpdateTextModel, Guid>
    {

    }
}
