using Business.Abstractions;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Users;

namespace Business
{
    public class UserService(DataContext dataContext) : DbEntityService<GetUserModel, CreateUserModel, UpdateUserModel, User, long>(dataContext), IUserService
    {
        public GetUserModel? Find(string name)
        {
            var user = dataContext.Users.SingleOrDefault((u) => u.Name == name);
            return user is not null ? GetUserModel.ToModel(user) : null;
        }

        public async Task<GetUserModel?> FindAsync(string name)
        {
            var user = await dataContext.Users.SingleOrDefaultAsync((u) => u.Name == name);
            return user is not null ? GetUserModel.ToModel(user) : null;
        }

        public GetUserModel? Find(string name, string? password)
        {
            var user = dataContext.Users.SingleOrDefault((u) => u.Name == name && (string.IsNullOrEmpty(password) ? string.IsNullOrEmpty(u.Password) : u.Password == password));
            
            return user is not null ? GetUserModel.ToModel(user) : null;
        }

        public async Task<GetUserModel?> FindAsync(string name, string? password)
        {
            var user = await dataContext.Users.SingleOrDefaultAsync((u) => u.Name == name && (string.IsNullOrEmpty(password) ? string.IsNullOrEmpty(u.Password) : u.Password == password));
            return user is not null ? GetUserModel.ToModel(user) : null;
        }
    }
}
