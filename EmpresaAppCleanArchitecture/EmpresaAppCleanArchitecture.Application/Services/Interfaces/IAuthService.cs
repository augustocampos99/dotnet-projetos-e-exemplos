using System;
using System.Collections.Generic;
using System.Text;

namespace EmpresaAppCleanArchitecture.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);
        string HashPassword(string password);
        bool ValidateHashPassword(string password, string passwordHash);
        string GetValueJwtToken(string jwt, string value);
    }
}
