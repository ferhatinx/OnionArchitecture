using System.Text;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Application.Tools
{
    public static class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            #region Claim Ekleme 
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(dto.Role))
                 claims.Add(new Claim(ClaimTypes.Role,dto.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));
            if(!string.IsNullOrWhiteSpace(dto.Username))
                claims.Add(new Claim("Username",dto.Username));
            
            #endregion
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.securityKey));
            var signingCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.expire);
            
            
            JwtSecurityToken token= new JwtSecurityToken(
                issuer:JwtTokenDefaults.validIssuer,
                audience:JwtTokenDefaults.validAudience,
                claims:claims,
                notBefore:DateTime.UtcNow,
                expires:expireDate,
                signingCredentials:null);





            JwtSecurityTokenHandler tokenHandler =new();
            string writedToken = tokenHandler.WriteToken(token);
            return new TokenResponseDto(writedToken,expireDate);
        }
    }
}