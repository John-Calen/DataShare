using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Texts;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class TextElementController : ControllerBase
    {
        private readonly ITextElementService textElementService;





        public TextElementController(ITextElementService textElementService)
        {
            this.textElementService = textElementService;
        }






        [HttpGet]
        public async Task<IEnumerable<GetTextModel>> Get()
        {
            return await textElementService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetTextModel?> Get([FromRoute] Guid id)
        {
            return await textElementService.GetAsync(id);
        }

        [HttpPost]
        public async Task<GetTextModel> Create([FromBody] CreateTextModel model)
        {
            return await textElementService.CreateAsync(model);
        }

        [HttpPut]
        public async Task<GetTextModel> Update([FromBody] UpdateTextModel model)
        {
            return await textElementService.UpdateAsync(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id) 
        {
            await textElementService.DeleteAsync(id);
        }
    }
}
