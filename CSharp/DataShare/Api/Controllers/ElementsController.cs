using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ElementsController : ControllerBase
    {
        private readonly IElementService elementService;





        public ElementsController(IElementService elementService)
        {
            this.elementService = elementService;
        }






        [HttpGet]
        public async Task<IEnumerable<ElementModel>> Get()
        {
            return await elementService.GetAsync();
        }

        [HttpGet("{id}/{type}")]
        public async Task<ElementModel?> Get([FromRoute] Guid id, [FromRoute] ElementType type)
        {
            return await elementService.GetAsync(id, type);
        }
    }
}
