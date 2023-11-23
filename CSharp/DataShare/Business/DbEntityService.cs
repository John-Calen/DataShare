using Business.Abstractions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Business
{
    public class DbEntityService<T_GetModel, T_CreateModel, T_UpdateModel, T_Entity, T_EntityPrimaryKey> : ICrudService<T_GetModel, T_CreateModel, T_UpdateModel, T_EntityPrimaryKey>
        where T_GetModel: IGetDbEntiyModel<T_Entity, T_GetModel>
        where T_CreateModel: IDbModel<T_Entity, T_CreateModel>
        where T_UpdateModel: IDbModel<T_Entity, T_UpdateModel>
        where T_Entity: class, IEntity<T_EntityPrimaryKey>
        where T_EntityPrimaryKey: notnull
    {
        protected readonly DataContext dataContext;





        public DbEntityService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }






        public virtual T_GetModel Create(T_CreateModel resource)
        {
            var entity = resource.ToEntity();
            var entry = dataContext.Set<T_Entity>()
                .Add(entity);
            dataContext.SaveChanges();

            return T_GetModel.ToModel(entry.Entity);
        }

        public virtual async Task<T_GetModel> CreateAsync(T_CreateModel resource)
        {
            var entity = resource.ToEntity();
            var entry = dataContext.Set<T_Entity>()
                .Add(entity);
            await dataContext.SaveChangesAsync();

            return T_GetModel.ToModel(entry.Entity);
        }

        public virtual void Delete(T_GetModel resource)
        {
            var entity = resource.ToEntity();
            entity = FindCached(entity) ?? entity;

            dataContext.Set<T_Entity>()
                .Remove(entity);
            
            dataContext.SaveChanges();
        }

        public virtual void Delete(T_EntityPrimaryKey id)
        {
            var entity = dataContext.Set<T_Entity>()
                .Find(id)!;

            dataContext.Remove(entity);
            dataContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T_GetModel resource)
        {
            var entity = resource.ToEntity();
            entity = FindCached(entity) ?? entity;

            dataContext.Set<T_Entity>()
                .Remove(entity);
            
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T_EntityPrimaryKey id)
        {
            var entity = dataContext.Set<T_Entity>()
                .Find(id)!;
         
            dataContext.Remove(entity);
            await dataContext.SaveChangesAsync();
        }

        public virtual IEnumerable<T_GetModel> Get()
        {
            return dataContext.Set<T_Entity>()
                .ToArray()
                .Select(T_GetModel.ToModel);
        }

        public virtual T_GetModel? Get(T_EntityPrimaryKey id)
        {
            var entity = dataContext.Set<T_Entity>()
                .Find(id);
            
            return entity is not null ? T_GetModel.ToModel(entity) : default;
        }

        public virtual async Task<IEnumerable<T_GetModel>> GetAsync()
        {
            var entities = await dataContext.Set<T_Entity>()
               .ToArrayAsync();

            return entities.Select(T_GetModel.ToModel);
        }

        public virtual async Task<T_GetModel?> GetAsync(T_EntityPrimaryKey id)
        {
            var entity = await dataContext.Set<T_Entity>()
                .FindAsync(id);
            
            return entity is not null ? T_GetModel.ToModel(entity) : default;
        }

        public virtual T_GetModel Update(T_UpdateModel resource)
        {
            var entity = resource.ToEntity();
            entity = FindCached(entity) ?? entity;

            var entry = dataContext.Set<T_Entity>()
                .Update(entity);

            dataContext.SaveChanges();

            return T_GetModel.ToModel(entry.Entity);
        }

        public virtual async Task<T_GetModel> UpdateAsync(T_UpdateModel resource)
        {
            var entity = resource.ToEntity();
            entity = FindCached(entity) ?? entity;

            var entry = dataContext.Set<T_Entity>()
                .Update(entity);
            
            await dataContext.SaveChangesAsync();

            return T_GetModel.ToModel(entry.Entity);
        }

        private T_Entity? FindCached(T_Entity entity)
        {
            var cached = dataContext.Set<T_Entity>()
                .Local
                .SingleOrDefault((e) => e.PrimaryKey.Equals(entity.PrimaryKey));

            return cached;
        }
    }
}
