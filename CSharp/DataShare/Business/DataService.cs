using Business.Abstractions;
using Models;

namespace Business
{
    public class DataService: IDataService
    {
        private readonly IFileDataService fileDataService;
        private readonly ITextDataService textDataService;






        public DataService(IFileDataService fileDataService, ITextDataService textDataService)
        {
            this.fileDataService = fileDataService;
            this.textDataService = textDataService;
        }





        public IEnumerable<DataModel> Get()
        {
            var textModels = textDataService.Get()
                .Select((te) => DataModel.FromText(te)!);

            var fileModels = fileDataService.Get()
                .Select((fe) => DataModel.FromFile(fe)!);

            return textModels.Concat(fileModels);
        }

        public async Task<IEnumerable<DataModel>> GetAsync()
        {
            var textModels = (await textDataService.GetAsync())
                .Select((te) => DataModel.FromText(te)!);

            var fileModels = (await fileDataService.GetAsync())
                .Select((fe) => DataModel.FromFile(fe)!);

            return textModels.Concat(fileModels);
        }

        public DataModel? Get(Guid id, DataType dataType)
        {
            return dataType switch
            {
                DataType.TEXT => DataModel.FromText(textDataService.Get(id)),
                DataType.FILE => DataModel.FromFile(fileDataService.Get(id))
            };
        }

        public async Task<DataModel?> GetAsync(Guid id, DataType dataType)
        {
            return dataType switch
            {
                DataType.TEXT => DataModel.FromText(await textDataService.GetAsync(id)),
                DataType.FILE => DataModel.FromFile(await fileDataService.GetAsync(id))
            };
        }
    }
}
