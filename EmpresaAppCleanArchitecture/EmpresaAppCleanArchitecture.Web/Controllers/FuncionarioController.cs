using EmpresaAppCleanArchitecture.Application.DTOs.Request;
using EmpresaAppCleanArchitecture.Application.DTOs.Response;
using EmpresaAppCleanArchitecture.Application.Exceptions;
using EmpresaAppCleanArchitecture.Application.Services;
using EmpresaAppCleanArchitecture.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmpresaAppCleanArchitecture.Web.Controllers
{
    [Route("api/v1/funcionarios")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;            
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

            var result = await this._funcionarioService.FindAll(limit, skip);
            return Ok(result);
        }

        [HttpGet("pesquisa")]
        public async Task<IActionResult> GetByName()
        {
            string nome = "-";
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

            if (!String.IsNullOrEmpty(Request.Query["nome"]))
            {
                nome = Request.Query["nome"];
            }

            var result = await this._funcionarioService.FindAllByNome(nome, limit, skip);
            return Ok(result);
        }

        [HttpGet("departamento/{departamentoId}")]
        public async Task<IActionResult> GetByDepartamentoId(Guid departamentoId)
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

            try
            {
                var result = await this._funcionarioService.FindAllByDepartamento(departamentoId, limit, skip);
                return Ok(result);
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

        [HttpGet("cargo/{cargoId}")]
        public async Task<IActionResult> GetByCargoId(Guid cargoId)
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

            try {
                var result = await this._funcionarioService.FindAllByCargo(cargoId, limit, skip);
                return Ok(result);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await this._funcionarioService.FindOneById(id);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Server error. Contact I.T" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FuncionarioRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await this._funcionarioService.Create(request);
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
        public async Task<IActionResult> Update([FromBody] FuncionarioRequest request, Guid id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await this._funcionarioService.Update(id, request);

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
                await this._funcionarioService.Delete(id);
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
