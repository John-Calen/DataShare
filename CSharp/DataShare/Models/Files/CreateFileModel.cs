using Models.Users;

namespace Models.Files
{
    public class CreateFileModel : ICreateFileModel
    {
        public required FileInfo File { get; init; }
        public string Name => File.Name;
        public long Size => File.Length;
        public required long OwnerId { get; init; }






        public Stream CreateStream()
        {
            return File.OpenRead();
        }
    }
}
