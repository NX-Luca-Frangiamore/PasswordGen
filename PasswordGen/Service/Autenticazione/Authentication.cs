﻿using Microsoft.AspNetCore.Authentication;
using PasswordGen.Model;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PasswordGen.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace PasswordGen.Service.Autenticazione
{
    public class Authentication
    {
        private IManagerDb Db;
        public Authentication(IManagerDb db) {
            this.Db = db;
        }
        private string GenerateToken(Utente user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim("username",user.UsernameUtente),
                new Claim("password",user.PasswordUtente),
                new Claim(ClaimTypes.Role,"user")
            }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("6ceccd7405ef4b00b2630009be568cfa")), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<string?> Login(string username, string password)
        {
            if((await Db.GetUtente(username, password)) is Utente u)
            {
                return GenerateToken(u);
            }
            return default;
        }
    }
}