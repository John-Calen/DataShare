using System.Security.Claims;

namespace Business.Abstractions
{
    public interface IJwtTokenService
    {
        public abstract string GenerateToken(IEnumerable<Claim> claims, DateTime expires);
    }
}
