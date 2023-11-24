using Api.Dtos;
using Business.Abstractions;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Files;
using Models.Files.Metas;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class FileDataController : ControllerBase
    {
        private readonly IFileDataService fileDataService;





        public FileDataController(IFileDataService fileElementService)
        {
            this.fileDataService = fileElementService;
        }






        [HttpGet]
        public async Task<IEnumerable<GetFileMetaModel>> Get()
        {
            return await fileDataService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<GetFileMetaModel?> Get([FromRoute] Guid id)
        {
            return await fileDataService.GetAsync(id);
        }

        [HttpGet("Download/{id}")]
        public IActionResult Download([FromRoute] Guid id)
        {
            var loadingFile = fileDataService.Load(id);
            return File(loadingFile.Stream, "application/octet-stream", loadingFile.Meta.Name);
        }

        [HttpPost]
        public async Task<GetFileMetaModel> Create([FromForm] CreateFileDto dto)
        {
            var result = await fileDataService.CreateAsync(dto);
            return result;
        }
        
        [HttpPut]
        public async Task<GetFileMetaModel> Update([FromForm] UpdateFileDto dto)
        {
            return await fileDataService.UpdateAsync(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id) 
        {
            await fileDataService.DeleteAsync(id);
        }
    }
}
