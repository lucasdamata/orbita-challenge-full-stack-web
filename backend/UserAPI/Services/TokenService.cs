using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class TokenService
    {
        public Token Create(IdentityUser<int> user)
        {
            Claim[] claimUser = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString()),
                //new Claim(ClaimTypes.Role, role),

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("#9y5i^{Mb/8 u))WBy&F][*E#r@`Ad@.R~I6E~aD"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claimUser,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(3)
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
