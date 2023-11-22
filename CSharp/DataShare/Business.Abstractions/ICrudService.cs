namespace Business.Abstractions
{
    public interface ICrudService<T_GetResource, T_CreateResource, T_UpdateResource, T_ResourceId>
    {
        public IEnumerable<T_GetResource> Get();
        public Task<IEnumerable<T_GetResource>> GetAsync();
        public T_GetResource? Get(T_ResourceId id);
        public Task<T_GetResource?> GetAsync(T_ResourceId id);
        public T_GetResource Create(T_CreateResource resource);
        public Task<T_GetResource> CreateAsync(T_CreateResource resource);
        public T_GetResource Update(T_UpdateResource resource);
        public Task<T_GetResource> UpdateAsync(T_UpdateResource resource);
        public void Delete(T_GetResource resource);
        public Task DeleteAsync(T_GetResource resource);
        public void Delete(T_ResourceId id);
        public Task DeleteAsync(T_ResourceId id);
    }
}
