using Models;
using Models.Users;

namespace Business.Abstractions
{
    public interface IUserService : ICrudService<GetUserModel, CreateUserModel, UpdateUserModel, long>
    {
        public abstract GetUserModel? Find(string name);
        public abstract Task<GetUserModel?> FindAsync(string name);
        public abstract GetUserModel? Find(string name, string? password);
        public abstract Task<GetUserModel?> FindAsync(string name, string? password);
    }
}
