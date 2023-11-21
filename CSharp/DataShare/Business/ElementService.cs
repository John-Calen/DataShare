using Models;

namespace Business
{
    public class ElementService: IElementService
    {
        private readonly IFileElementService fileElementService;
        private readonly ITextElementService textElementService;






        public ElementService(IFileElementService fileElementService, ITextElementService textElementService)
        {
            this.fileElementService = fileElementService;
            this.textElementService = textElementService;
        }





        public IEnumerable<ElementModel> Get()
        {
            var textModels = textElementService.Get()
                .Select((te) => ElementModel.FromText(te)!);

            var fileModels = fileElementService.Get()
                .Select((fe) => ElementModel.FromFile(fe)!);

            return textModels.Concat(fileModels);
        }

        public async Task<IEnumerable<ElementModel>> GetAsync()
        {
            var textModels = (await textElementService.GetAsync())
                .Select((te) => ElementModel.FromText(te)!);

            var fileModels = (await fileElementService.GetAsync())
                .Select((fe) => ElementModel.FromFile(fe)!);

            return textModels.Concat(fileModels);
        }

        public ElementModel? Get(Guid id, ElementType elementType)
        {
            return elementType switch
            {
                ElementType.TEXT => ElementModel.FromText(textElementService.Get(id)),
                ElementType.FILE => ElementModel.FromFile(fileElementService.Get(id))
            };
        }

        public async Task<ElementModel?> GetAsync(Guid id, ElementType elementType)
        {
            return elementType switch
            {
                ElementType.TEXT => ElementModel.FromText(await textElementService.GetAsync(id)),
                ElementType.FILE => ElementModel.FromFile(await fileElementService.GetAsync(id))
            };
        }
    }
}
