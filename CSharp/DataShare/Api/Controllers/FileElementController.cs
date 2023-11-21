using Api.Dtos;
using Business;
using Microsoft.AspNetCore.Mvc;
using Models.Files;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileElementController : ControllerBase
    {
        private readonly IFileElementService fileElementService;





        public FileElementController(IFileElementService fileElementService)
        {
            this.fileElementService = fileElementService;
        }






        [HttpGet]
        public async Task<IEnumerable<GetFileModel>> Get()
        {
            return await fileElementService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetFileModel?> Get([FromRoute] Guid id)
        {
            return await fileElementService.GetAsync(id);
        }

        [HttpPost]
        public async Task<GetFileModel> Create([FromForm] CreateFileDto dto)
        {
            return await fileElementService.CreateAsync(dto);
        }
        
        [HttpPut]
        public async Task<GetFileModel> Update([FromForm] UpdateFileDto dto)
        {
            return await fileElementService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id) 
        {
            await fileElementService.DeleteAsync(id);
        }
    }
}
