using Business.Abstractions;
using Data;
using Data.Entities;
using Models.Texts;

namespace Business
{
    public class TextDataService : DbEntityService<GetTextModel,CreateTextModel, UpdateTextModel, Text, Guid>, ITextDataService
    {
        public TextDataService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
