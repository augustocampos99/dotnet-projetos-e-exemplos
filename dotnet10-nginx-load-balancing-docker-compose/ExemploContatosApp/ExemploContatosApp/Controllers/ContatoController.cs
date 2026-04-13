using ExemploContatosApp.Entities;
using ExemploContatosApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetAll()
        {
            return Ok(_contatoService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(Guid id)
        {
            return Ok(_contatoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contato contato)
        {
            return Ok(_contatoService.Create(contato));
        }

        [HttpPut("{id}")]
        public IActionResult Create(Guid id, [FromBody] Contato contato)
        {
            return Ok(_contatoService.Update(id, contato));
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _contatoService.Delete(id);
            return Ok();
        }

    }
}
