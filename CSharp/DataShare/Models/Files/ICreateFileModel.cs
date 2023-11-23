namespace Models.Files
{
    public interface ICreateFileModel
    {
        public abstract string Name { get; }
        public abstract long OwnerId { get; }
        public Stream CreateStream();
    }
}
