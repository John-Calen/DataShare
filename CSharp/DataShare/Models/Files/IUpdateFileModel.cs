namespace Models.Files
{
    public interface IUpdateFileModel
    {
        public abstract Guid Id { get; }
        public abstract string Name { get; }
        public abstract long Size { get; }
        public abstract DateTime CreatedAt { get; }
        public abstract long OwnerId { get; }
        public Stream CreateStream();
    }
}
