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
        public long Size => throw new NotImplementedException();
        private DateTime createdAt = DateTime.UtcNow;
        public DateTime CreatedAt => createdAt;
        [Required]
        public long OwnerId { get; set; }






        public Stream CreateStream()
        {
            return File.OpenReadStream();
        }
    }
}
