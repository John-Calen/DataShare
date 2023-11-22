using Business.Abstractions;

namespace Business
{
    public class JwtSettings : IJwtSettings
    {
        public required string Key { get; init; }
        public required string Issuer { get; init; }
        public required string Audience { get; init; }
    }
}
