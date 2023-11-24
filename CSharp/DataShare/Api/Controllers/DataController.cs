using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;





        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }






        [HttpGet]
        public async Task<IEnumerable<DataModel>> Get()
        {
            return await dataService.GetAsync();
        }

        [HttpGet("{id}/{type}")]
        public async Task<DataModel?> Get([FromRoute] Guid id, [FromRoute] DataType type)
        {
            return await dataService.GetAsync(id, type);
        }
    }
}
