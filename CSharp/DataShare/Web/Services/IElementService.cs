using Models;

namespace Web.Services
{
    public interface IElementService
    {
        public Task<IEnumerable<ElementModel>?> GetAsync();
    }
}
