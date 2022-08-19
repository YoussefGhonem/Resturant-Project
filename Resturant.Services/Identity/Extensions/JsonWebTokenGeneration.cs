using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Resturant.Core.CurrentUser;
using Resturant.Data.DbModels.SecuritySchema;
using Resturant.Services.Identity.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace Resturant.Services.Identity.Extensions
{
    public static class JsonWebTokenGeneration
    {
        public static string GenerateJwtToken(IConfiguration configuration, ApplicationUser user)
        {
            var clientConfig = configuration.GetJwtConfig();

            var signingKey = Convert.FromBase64String(clientConfig.Key);

            #region Add Claims

            var claims = new List<Claim>();
            AddClaim(claims, ClaimKeys.Id, user.Id.ToString());
            AddClaim(claims, ClaimKeys.Email, user.Email);
            AddClaim(claims, ClaimKeys.FirstName, user.FirstName);
            AddClaim(claims, ClaimKeys.LastName, user.LastName);
            AddClaim(claims, ClaimKeys.Name, user.FirstName + ' ' + user.LastName);

            claims.AddRange(user.UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Name)));

            #endregion

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = clientConfig.Issuer,
                Audience = clientConfig.Audience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(clientConfig.ExpiryDuration),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            return token;
        }
        #region Add Claims Helper Methods 
        private static void AddClaim(List<Claim> claims, string propKey, string? propValue)
        {
            if (string.IsNullOrEmpty(propValue)) return;
            claims.Add(new Claim(propKey, propValue));
        }
        #endregion
    }
}