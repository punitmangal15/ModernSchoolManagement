using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace ModernSchoolManagement.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly IConfiguration _configuration;
        private readonly string _audience;
        public readonly string _accessToken;
        public bool ValidStatus = false;

        public Authentication(IConfiguration configuration)
        {
            _configuration = configuration;
            _audience = _configuration["Jwt:Audience"];
        }
         public bool ValidateTokenCLaim(string tokenValue)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(tokenValue)|| !tokenHandler.CanReadToken(tokenValue))
                return ValidStatus;

            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var readableToken = tokenHandler.ReadToken(tokenValue);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

            try
            {
                tokenHandler.ValidateToken(tokenValue, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

public string GenerateJwtToken(IEnumerable<Claim> claims, int expiresMinutes = 60)
{
    var key = _configuration["Jwt:Key"];
    var issuer = _configuration["Jwt:Issuer"];
    var audience = _configuration["Jwt:Audience"];
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
        
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddMinutes(expiresMinutes),
        Issuer = issuer,
        Audience = audience,
        SigningCredentials = credentials
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}
    }
}
