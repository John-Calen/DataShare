using Models.Files.Metas;

namespace Models.Files
{
    public class LoadingFileModel
    {
        public required GetFileMetaModel Meta { get; init; }
        public required Stream Stream { get; init; }
    }
}
