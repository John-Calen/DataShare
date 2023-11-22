using System.Text.Json.Serialization;

namespace Models
{
    public class AuthToken
    {
        [JsonPropertyName("jwtAccess")]
        public string JwtAccess { get; set; } = default!;
        [JsonPropertyName("jwtRefresh")]
        public string JwtRefresh { get; set; } = default!;
    }
}
