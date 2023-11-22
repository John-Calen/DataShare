using Data.Entities;
using System.Text.Json.Serialization;

namespace Models.Users
{
    public class UpdateUserModel : IDbModel<User, UpdateUserModel>
    {
        [JsonPropertyName("id")]
        public long Id { get; set; } = default!;
        [JsonPropertyName("name")] 
        public string Name { get; set; } = default!;






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
