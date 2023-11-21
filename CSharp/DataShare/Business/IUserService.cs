using Models.Users;

namespace Business
{
    public interface IUserService: ICrudService<GetUserModel, CreateUserModel, UpdateUserModel, long>
    {

    }
}
