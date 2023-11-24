using Models;

namespace Business.Abstractions
{
    public interface IDataService
    {
        public abstract IEnumerable<DataModel> Get();
        public abstract Task<IEnumerable<DataModel>> GetAsync();
        public abstract DataModel? Get(Guid id, DataType dataType);
        public abstract Task<DataModel?> GetAsync(Guid id, DataType dataType);
    }
}
