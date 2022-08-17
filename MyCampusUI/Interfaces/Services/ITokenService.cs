using System.Security.Claims;

namespace MyCampusUI.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims, DateTime expiresAt);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
