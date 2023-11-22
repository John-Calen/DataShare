using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Users
{
    public class CreateUserModel : IDbModel<User, CreateUserModel>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("password")]
        public string? Password { get; set; }






        public User ToEntity()
        {
            return new User
            {
                Name = Name,
                Password = Password
            };
        }
    }
}
