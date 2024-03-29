﻿using CoreAPI.Model;
using CoreAPI.Responsitory.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreAPI.Responsitory
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private IConfiguration _config;

        public AuthenticationRepository(IConfiguration config)
        {
            _config = config;
        }

        public string GetJwtToken(Member member)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,member.Email),
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
               audience: _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
