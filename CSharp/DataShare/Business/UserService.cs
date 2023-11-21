using Data;
using Data.Entities;
using Models.Users;

namespace Business
{
    public class UserService(DataContext dataContext) : DbEntityService<GetUserModel, CreateUserModel, UpdateUserModel, User, long>(dataContext), IUserService
    {
    }
}
