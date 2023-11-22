using Business.Abstractions;
using Data;
using Data.Entities;
using Models.Texts;

namespace Business
{
    public class TextElementService : DbEntityService<GetTextModel,CreateTextModel, UpdateTextModel, Text, Guid>, ITextElementService
    {
        public TextElementService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
