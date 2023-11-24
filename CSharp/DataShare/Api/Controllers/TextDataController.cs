using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Texts;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TextDataController : ControllerBase
    {
        private readonly ITextDataService textDataService;





        public TextDataController(ITextDataService textElementService)
        {
            this.textDataService = textElementService;
        }






        [HttpGet]
        public async Task<IEnumerable<GetTextModel>> Get()
        {
            return await textDataService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetTextModel?> Get([FromRoute] Guid id)
        {
            return await textDataService.GetAsync(id);
        }

        [HttpPost]
        public async Task<GetTextModel> Create([FromBody] CreateTextModel model)
        {
            return await textDataService.CreateAsync(model);
        }

        [HttpPut]
        public async Task<GetTextModel> Update([FromBody] UpdateTextModel model)
        {
            return await textDataService.UpdateAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id) 
        {
            await textDataService.DeleteAsync(id);
        }
    }
}
