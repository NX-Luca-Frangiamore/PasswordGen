﻿using PasswordGen.Model;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PasswordGen.Repository;


namespace PasswordGen.Service.Autenticazione
{
    public class Authentication
    {
        private IManagerDb Db;
        private IConfiguration Configuration;
        public Authentication(IManagerDb db) {
            this.Db = db;
            Configuration = new ConfigurationBuilder()
                                   .AddJsonFile("appsettings.json")
                                   .AddEnvironmentVariables()
                                   .Build();
        }
        private string GenerateToken(Utente user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim("username",user.UsernameUtente),
                new Claim("id",user.Id+""),
                new Claim(ClaimTypes.Role,"user")
            }),
                // Issuer="Luca", chi emette
                //Audience=, chi deve ricevere il token
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Configuration.GetValue<byte[]>("key")), SecurityAlgorithms.HmacSha256Signature)
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