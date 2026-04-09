using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.DTOs.Response;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAppCleanArchitecture.Web.Controllers
{
    [Route("api/v1/cargos")]
    [ApiController]
    [Authorize(Roles = "Admin, Master")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int limit = 10;
            int skip = 0;

            if (!String.IsNullOrEmpty(Request.Query["limit"]) && !String.IsNullOrEmpty(Request.Query["skip"]))
            {
                try
                {
                    limit = Int32.Parse(Request.Query["limit"]);
                    skip = Int32.Parse(Request.Query["skip"]);
                }
                catch (Exception ex)
                {
                    return BadRequest("Invalid parameter!");
                }
            }

            var result = await this._cargoService.FindAll(limit, skip);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CargoRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await this._cargoService.Create(request);
                    return Ok(result);
                }
                catch (NotFoundException ex)
                {
                    return NotFound();
                }
                catch (BadRequestException ex)
                {
                    return BadRequest(new BadRequestResponseDTO { Code = 400, Message = ex.Message });
                }
                catch (Exception ex)
                {
                    return BadRequest("Server error. Contact I.T" + ex.Message);
                }
            }

            return BadRequest("");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CargoRequest request, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await this._cargoService.Update(id, request);

                    if (result == null)
                    {
                        return NotFound();
                    }

                    return Ok(result);
                }
                catch (BadRequestException ex)
                {
                    return BadRequest(new BadRequestResponseDTO { Code = 400, Message = ex.Message });
                }
                catch (NotFoundException ex)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest("Server error. Contact I.T");
                }
            }

            return BadRequest("");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await this._cargoService.Delete(id);
                return Ok("ok");
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Server error. Contact I.T");
            }
        }
    }
}
