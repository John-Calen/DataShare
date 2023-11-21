using Data.Entities;

namespace Models.Users
{
    public class GetUserModel : IGetDbEntiyModel<User, GetUserModel>
    {
        public required long Id { get; init; }
        public required string Name { get; init; }






        public static GetUserModel ToModel(User entity)
        {
            return new GetUserModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public User ToEntity()
        {
            return new User
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
