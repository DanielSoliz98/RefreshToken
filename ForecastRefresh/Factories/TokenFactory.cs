using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forecast.Factories
{
    public class TokenFactory : ITokenFactory
    {
        public string GenerateAccessToken(Models.User user)
        {
            // Preconditions
            Contract.Requires(user != null);

            Claim[] claims = new Claim[2]
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username)
            };

            byte[] key = Encoding.ASCII.GetBytes("this_is_a_long_secret_key");
            
            JwtSecurityToken tokenDescriptor = new JwtSecurityToken(
                issuer: "localhost:62517",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public string GenerateRefreshToken()
        {
            return Guid.NewGuid().ToString("N", null);
        }
    }
}
