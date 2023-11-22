using Models;

namespace Business.Abstractions
{
    public interface IElementService
    {
        public abstract IEnumerable<ElementModel> Get();
        public abstract Task<IEnumerable<ElementModel>> GetAsync();
        public abstract ElementModel? Get(Guid id, ElementType elementType);
        public abstract Task<ElementModel?> GetAsync(Guid id, ElementType elementType);
    }
}
