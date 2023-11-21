using Data.Entities;

namespace Models.Users
{
    public class CreateUserModel : IDbModel<User, CreateUserModel>
    {
        public required string Name { get; init; }






        public User ToEntity()
        {
            return new User
            {
                Name = Name
            };
        }
    }
}
