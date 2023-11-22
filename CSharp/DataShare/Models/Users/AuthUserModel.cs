using System.Text.Json.Serialization;

namespace Models.Users
{
    public class AuthUserModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;
        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}
