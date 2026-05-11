using InternetBanking.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Web.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int skip = 0;
            int limit = 10;

            if (!String.IsNullOrEmpty(Request.Query["limit"]) && !String.IsNullOrEmpty(Request.Query["skip"]))
            {
                try
                {
                    skip = Int32.Parse(Request.Query["skip"]);
                    limit = Int32.Parse(Request.Query["limit"]);
                }
                catch (Exception ex)
                {
                    return BadRequest("Invalid parameter!");
                }
            }

            var result = await this._userService.FindAll(skip, limit);
            return Ok(result);
        }

    }
}
