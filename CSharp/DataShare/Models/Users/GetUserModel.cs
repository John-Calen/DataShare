using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Users
{
    public class GetUserModel : IGetDbEntiyModel<User, GetUserModel>
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")] 
        public string Name { get; set; } = default!;






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
