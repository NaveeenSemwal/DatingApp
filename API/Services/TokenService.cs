using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        }

        public string CreateToken(AppUser appUser)
        {
           var claims = new[] {
            new Claim(
                JwtRegisteredClaimNames.NameId,
                appUser.UserName)
           };

          var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

          var tokenDescriptor= new SecurityTokenDescriptor {

               Subject= new ClaimsIdentity(claims),
               Expires= DateTime.Now.AddMinutes(30), 
               SigningCredentials= creds
          }; 

           var tokenHandler= new JwtSecurityTokenHandler();
           var token= tokenHandler.CreateToken(tokenDescriptor);

           return tokenHandler.WriteToken(token);
        }
    }
}