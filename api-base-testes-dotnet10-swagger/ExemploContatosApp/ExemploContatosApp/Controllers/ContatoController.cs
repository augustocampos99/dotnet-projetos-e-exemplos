using ExemploContatosApp.Entities;
using ExemploContatosApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExemploContatosApp.Controllers
{
    [Route("api/v1/contatos")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contatoService.FindAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var result = await _contatoService.FindById(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Contato contato)
        {
            var result = await _contatoService.Create(contato);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Contato contato)
        {
            var result = await _contatoService.Update(id, contato);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contatoService.Delete(id);
            return Ok();
        }

    }
}
