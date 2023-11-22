using Business.Abstractions;
using Data;
using Data.Entities;
using Models.Files;
using Models.Files.Metas;

namespace Business
{
    public class FileElementService: IFileElementService
    {
        private readonly DataContext dataContext;
        private readonly IFileStorage fileStorage;
        private readonly DbEntityService<GetFileMetaModel, CreateFileMetaModel, UpdateFileMetaModel, FileMeta, Guid> metaService;
        
            
            
            
            
            
        public FileElementService(DataContext dataContext, IFileStorage fileStorage)
        {
            this.dataContext = dataContext;
            this.fileStorage = fileStorage;
            metaService = new DbEntityService<GetFileMetaModel, CreateFileMetaModel, UpdateFileMetaModel, FileMeta, Guid>(dataContext);
        }






        public GetFileModel Create(ICreateFileModel resource)
        {
            using var transaction = dataContext.Database.BeginTransaction();
            
            var id = default(Guid?);
            try
            {
                var metaModel = new CreateFileMetaModel
                {
                    Name = resource.Name,
                    OwnerId = resource.OwnerId
                };

                var created = metaService.Create(metaModel);
                id = created.Id;
                
                transaction.Commit();

                long size = 0;
                using (var stream = resource.CreateStream())
                {
                    size = fileStorage.Save(id.Value, stream);
                }

                var updated = metaService.Update
                (
                    new UpdateFileMetaModel
                    { 
                        Id = created.Id,
                        CreatedAt = created.CreatedAt,
                        Name = created.Name,
                        OwnerId = created.OwnerId,
                        Size = size
                    }
                );

                transaction.Commit();

                return new GetFileModel
                {
                    Meta = updated
                };
            }

            catch
            {
                if (id is not null)
                {
                    using (var stream = resource.CreateStream())
                    {
                        fileStorage.Delete(id.Value);
                    }
                }

                throw new Exception("Could not create");
            }
        }

        public async Task<GetFileModel> CreateAsync(ICreateFileModel resource)
        {
            using var transaction = await dataContext.Database.BeginTransactionAsync();

            var id = default(Guid?);
            try
            {
                var metaModel = new CreateFileMetaModel
                {
                    Name = resource.Name,
                    OwnerId = resource.OwnerId
                };

                var created = await metaService.CreateAsync(metaModel);
                id = created.Id;

                await transaction.CommitAsync();

                long size = 0;
                using (var stream = resource.CreateStream())
                {
                    size = await fileStorage.SaveAsync(id.Value, stream);
                }

                var updated = await metaService.UpdateAsync
                (
                    new UpdateFileMetaModel
                    {
                        Id = created.Id,
                        CreatedAt = created.CreatedAt,
                        Name = created.Name,
                        OwnerId = created.OwnerId,
                        Size = size
                    }
                );

                await transaction.CommitAsync();

                return new GetFileModel
                {
                    Meta = updated
                };
            }

            catch
            {
                if (id is not null)
                {
                    using (var stream = resource.CreateStream())
                    {
                        fileStorage.Delete(id.Value);
                    }
                }

                throw new Exception("Could not create");
            }
        }

        public void Delete(GetFileModel resource)
        {
            using var transaction = dataContext.Database.BeginTransaction();

            metaService.Delete(resource.Meta.Id);
            fileStorage.Delete(resource.Meta.Id);

            transaction.Commit();
        }

        public void Delete(Guid id)
        {
            using var transaction = dataContext.Database.BeginTransaction();

            metaService.Delete(id);
            fileStorage.Delete(id);

            transaction.Commit();
        }

        public async Task DeleteAsync(GetFileModel resource)
        {
            using var transaction = await dataContext.Database.BeginTransactionAsync();

            await metaService.DeleteAsync(resource.Meta.Id);
            fileStorage.Delete(resource.Meta.Id);

            transaction.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            using var transaction = await dataContext.Database.BeginTransactionAsync();

            await metaService.DeleteAsync(id);
            fileStorage.Delete(id);

            transaction.Commit();
        }

        public IEnumerable<GetFileModel> Get()
        {
            return metaService.Get()
                .Select((meta) => new GetFileModel { Meta = meta });
        }

        public GetFileModel? Get(Guid id)
        {
            var meta = metaService.Get(id);
            return meta is not null 
                ? new GetFileModel { Meta = meta }
                : null;
        }

        public async Task<IEnumerable<GetFileModel>> GetAsync()
        {
            return (await metaService.GetAsync())
               .Select((meta) => new GetFileModel { Meta = meta });
        }

        public async Task<GetFileModel?> GetAsync(Guid id)
        {
            var meta = await metaService.GetAsync(id);
            return meta is not null
                ? new GetFileModel { Meta = meta }
                : null;
        }

        public Stream Load(Guid id)
        {
            return fileStorage.Load(id);
        }

        public Task<Stream> LoadAsync(Guid id)
        {
            return fileStorage.LoadAsync(id);
        }

        public void Load(Guid id, Stream to)
        {
            fileStorage.Load(id, to);
        }

        public Task LoadAsync(Guid id, Stream to)
        {
            return fileStorage.LoadAsync(id, to);
        }

        public GetFileModel Update(IUpdateFileModel resource)
        {
            //  Todo: Consider rollback of file storage

            using var transaction = dataContext.Database.BeginTransaction();

            var id = default(Guid?);
            var metaModel = new UpdateFileMetaModel
            {
                Id = resource.Id,
                Name = resource.Name,
                CreatedAt = resource.CreatedAt,
                OwnerId = resource.OwnerId,
                Size = 0
            };

            var created = metaService.Update(metaModel);
            id = created.Id;
                
            transaction.Commit();

            long size = 0;
            using (var stream = resource.CreateStream())
            {
                size = fileStorage.Replace(id.Value, stream);
            }

            var updated = metaService.Update
            (
                new UpdateFileMetaModel
                { 
                    Id = created.Id,
                    CreatedAt = created.CreatedAt,
                    Name = created.Name,
                    OwnerId = created.OwnerId,
                    Size = size
                }
            );

            transaction.Commit();

            return new GetFileModel
            {
                Meta = updated
            };
        }

        public async Task<GetFileModel> UpdateAsync(IUpdateFileModel resource)
        {
            //  Todo: Consider rollback of file storage

            using var transaction = await dataContext.Database.BeginTransactionAsync();

            var id = default(Guid?);
            var metaModel = new UpdateFileMetaModel
            {
                Id = resource.Id,
                Name = resource.Name,
                CreatedAt = resource.CreatedAt,
                OwnerId = resource.OwnerId,
                Size = 0
            };

            var created = await metaService.UpdateAsync(metaModel);
            id = created.Id;

            await transaction.CommitAsync();

            long size = 0;
            using (var stream = resource.CreateStream())
            {
                size = await fileStorage.ReplaceAsync(id.Value, stream);
            }

            var updated = await metaService.UpdateAsync
            (
                new UpdateFileMetaModel
                {
                    Id = created.Id,
                    CreatedAt = created.CreatedAt,
                    Name = created.Name,
                    OwnerId = created.OwnerId,
                    Size = size
                }
            );

            await transaction.CommitAsync();

            return new GetFileModel
            {
                Meta = updated
            };
        }
    }
}
