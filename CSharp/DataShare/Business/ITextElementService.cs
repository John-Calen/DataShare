using Models.Texts;

namespace Business
{
    public interface ITextElementService: ICrudService<GetTextModel, CreateTextModel, UpdateTextModel, Guid> 
    {

    }
}
