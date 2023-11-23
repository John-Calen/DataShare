namespace Data
{
    public class FileStorage : IFileStorage
    {
        private readonly string path;





        public FileStorage(string path) 
        {
            this.path = path;
        }







        public void Delete(Guid id)
        {
            var path = GetFilePath(id);

            if (!File.Exists(path))
                throw new Exception("File doesn't exist");

            File.Delete(path);
        }

        public bool Exists(Guid id)
        {
            var path = GetFilePath(id);
            return File.Exists(path);
        }

        public Stream Load(Guid id)
        {
            var path = GetFilePath(id);

            if ( ! File.Exists(path))
                throw new Exception("File doesn't exist");

            return File.OpenRead(path);
        }

        public void Load(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if ( ! File.Exists(path))
                throw new Exception("File doesn't exist");

            using var fileStream = File.OpenRead(path);
            fileStream.CopyTo(stream);
        }

        public async Task LoadAsync(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if (!File.Exists(path))
                throw new Exception("File doesn't exist");

            using var fileStream = File.OpenRead(path);
            await fileStream.CopyToAsync(stream);
        }

        public long Replace(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if ( ! File.Exists(path))
                throw new Exception("File doesn't exist");

            using var fileStream = File.Create(path);
            stream.CopyTo(fileStream);

            return new FileInfo(path).Length;
        }

        public async Task<long> ReplaceAsync(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if ( ! File.Exists(path))
                throw new Exception("File doesn't exist");

            using var fileStream = File.Create(path);
            await stream.CopyToAsync(fileStream);

            return new FileInfo(path).Length;
        }

        public long Save(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if (File.Exists(path))
                throw new Exception("File already exists");

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using var fileStream = File.OpenWrite(path);
            stream.CopyTo(fileStream);

            return new FileInfo(path).Length;
        }

        public async Task<long> SaveAsync(Guid id, Stream stream)
        {
            var path = GetFilePath(id);

            if (File.Exists(path))
                throw new Exception("File already exists");

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            using var fileStream = File.OpenWrite(path);
            await stream.CopyToAsync(fileStream);

            return new FileInfo(path).Length;
        }

        private string GetFilePath(Guid id)
        {
            var idStr = id.ToString();
            var path = this.path;
            foreach (var index in Enumerable.Range(0, 3))
                path = Path.Combine(path, idStr[index].ToString());

            return path;
        }
    }
}
