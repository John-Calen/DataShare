using Business.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IJwtSettings settings;





        public JwtTokenService(IJwtSettings settings)
        {
            this.settings = settings;
        }






        public string GenerateToken(IEnumerable<Claim> claims, DateTime expires)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                settings.Issuer,
                settings.Audience,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);

        }
    }
}
