using Business.Abstractions;
using Data;
using Data.Entities;
using Models.Files;
using Models.Files.Metas;

namespace Business
{
    public class FileDataService: IFileDataService
    {
        private readonly DataContext dataContext;
        private readonly IFileStorage fileStorage;
        private readonly DbEntityService<GetFileMetaModel, CreateFileMetaModel, UpdateFileMetaModel, FileMeta, Guid> metaService;
        
            
            
            
            
            
        public FileDataService(DataContext dataContext, IFileStorage fileStorage)
        {
            this.dataContext = dataContext;
            this.fileStorage = fileStorage;
            metaService = new DbEntityService<GetFileMetaModel, CreateFileMetaModel, UpdateFileMetaModel, FileMeta, Guid>(dataContext);
        }






        public GetFileMetaModel Create(ICreateFileModel resource)
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

                return updated;
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

        public async Task<GetFileMetaModel> CreateAsync(ICreateFileModel resource)
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

                return updated;
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

        public void Delete(GetFileMetaModel resource)
        {
            using var transaction = dataContext.Database.BeginTransaction();

            metaService.Delete(resource.Id);
            fileStorage.Delete(resource.Id);

            transaction.Commit();
        }

        public void Delete(Guid id)
        {
            using var transaction = dataContext.Database.BeginTransaction();

            metaService.Delete(id);
            fileStorage.Delete(id);

            transaction.Commit();
        }

        public async Task DeleteAsync(GetFileMetaModel resource)
        {
            using var transaction = await dataContext.Database.BeginTransactionAsync();

            await metaService.DeleteAsync(resource.Id);
            fileStorage.Delete(resource.Id);

            transaction.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            using var transaction = await dataContext.Database.BeginTransactionAsync();

            await metaService.DeleteAsync(id);
            fileStorage.Delete(id);

            transaction.Commit();
        }

        public IEnumerable<GetFileMetaModel> Get()
        {
            return metaService.Get();
        }

        public GetFileMetaModel? Get(Guid id)
        {
            return metaService.Get(id);
        }

        public async Task<IEnumerable<GetFileMetaModel>> GetAsync()
        {
            return await metaService.GetAsync();
        }

        public async Task<GetFileMetaModel?> GetAsync(Guid id)
        {
            return await metaService.GetAsync(id);
        }

        public LoadingFileModel Load(Guid id)
        {
            var meta = Get(id)!;
            var stream = fileStorage.Load(id);

            return new LoadingFileModel
            {
                Meta = meta,
                Stream = stream
            };
        }

        public GetFileMetaModel Load(Guid id, Stream to)
        {
            var meta = Get(id)!;
            fileStorage.Load(id, to);

            return meta;
        }

        public async Task<GetFileMetaModel> LoadAsync(Guid id, Stream to)
        {
            var meta = await GetAsync(id);
            await fileStorage.LoadAsync(id, to);

            return meta;
        }

        public GetFileMetaModel Update(IUpdateFileModel resource)
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

            return updated;
        }

        public async Task<GetFileMetaModel> UpdateAsync(IUpdateFileModel resource)
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

            return updated;
        }
    }
}
