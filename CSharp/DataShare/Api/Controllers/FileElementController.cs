using Api.Dtos;
using Business.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Files;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
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

        [HttpGet("Download/{id}")]
        public IActionResult Download([FromRoute] Guid id)
        {
            var loadingFile = fileElementService.Load(id);
            return File(loadingFile.Stream, "application/octet-stream", loadingFile.Meta.Name);
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
