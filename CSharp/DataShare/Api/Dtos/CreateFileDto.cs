using Models.Files;
using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class CreateFileDto: ICreateFileModel
    {
        [Required]
        public IFormFile File { get; set; } = default!;
        [Required]
        public string Name { get; set; } = default!;
        //  Todo: it should be specified based on authorized user
        [Required]
        public long OwnerId { get; set; }






        public Stream CreateStream()
        {
            return File.OpenReadStream();
        }
    }
}
