using Data.Entities;

namespace Models.Users
{
    public class UpdateUserModel : IDbModel<User, UpdateUserModel>
    {
        public required long Id { get; init; }
        public required string Name { get; init; }






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
