using System.Security.Claims;

namespace ModernSchoolManagement.Authentication
{
    public interface IAuthentication
    {
        bool ValidateTokenCLaim(string TokenValue);
        string GenerateJwtToken(IEnumerable<Claim> claims, int expiresMinutes=60);
    }
}
