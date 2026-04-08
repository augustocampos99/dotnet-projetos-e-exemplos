using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services
{
    public class AuthService : IAuthService
    {
        private string salt = "NI5xAMFEmzRK7IOGnKuMQgLUA3F2VDa7LVYrx0PMv";

        public async Task<string> Login(string email, string password)
        {
            // Essa autenticação é só para fins de teste
            if (email.Equals("admin") && password.Equals("admin"))
            {
                return this.GenerateToken(Guid.NewGuid(), email, "José Campos", "Admin");
            }


            throw new BadRequestException("Email ou Senha incorreto");
        }


        private string GenerateToken(Guid userId, string email, string name, string userRole)
        {
            // Create claims
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new(JwtRegisteredClaimNames.Email, email),
                new(JwtRegisteredClaimNames.Name, name),
            };

            claims.Add(new Claim(ClaimTypes.Role, userRole));

            // Create secutiry key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rD0vQkpTzqzd2P03YpvudaUq3VYtDhHF"));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // configure token descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = "https://abtestfactory.com",
                Audience = "https://abtestfactory.com",
                SigningCredentials = signingCredentials
            };

            // Generate token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string HashPassword(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password + salt, 13);
            return passwordHash;
        }

        public bool ValidateHashPassword(string password, string passwordHash)
        {
            bool verify = BCrypt.Net.BCrypt.EnhancedVerify(password + salt, passwordHash);
            return verify;
        }

        public string GetValueJwtToken(string jwt, string value)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            // Find the desired claim by its type and return its value
            var claim = token.Claims.FirstOrDefault(c => c.Type == value);

            return claim?.Value; // Return the claim's value or null if not found
        }

    }
}
