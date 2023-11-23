namespace Data
{
    public interface IFileStorage
    {
        public void Delete(Guid id);
        public bool Exists(Guid id);
        public Stream Load(Guid id);
        public void Load(Guid id, Stream stream);
        public Task LoadAsync(Guid id, Stream stream);
        public long Replace(Guid id, Stream stream);
        public Task<long> ReplaceAsync(Guid id, Stream stream);
        public long Save(Guid id, Stream stream);
        public Task<long> SaveAsync(Guid id, Stream stream);
    }
}
