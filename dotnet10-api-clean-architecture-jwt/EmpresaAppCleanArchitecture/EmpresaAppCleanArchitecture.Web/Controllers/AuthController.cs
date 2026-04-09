using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAppCleanArchitecture.Web.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("auth/login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tokenResult = await this._authService.Login(loginRequest.Email, loginRequest.Password);
                    return Ok(tokenResult);
                }
                catch (Exception ex)
                {
                    return Unauthorized("Email ou Senha incorreto");
                }
            }

            return BadRequest("");
        }

    }
}
