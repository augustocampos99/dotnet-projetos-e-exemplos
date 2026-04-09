using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PagamentoMensageria.Web.Entities;
using PagamentoMensageria.Web.Services;
using PagamentoMensageria.Web.Services.Interfaces;

namespace PagamentoMensageria.Web.Controllers
{
    [Route("api/pagamentos")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _pagamentoService;

        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;            
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pagamento pagamento)
        {
            try
            {
                var send = await _pagamentoService.SendMessage(pagamento);
                return Ok(send);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro no envio da mensagem: " + ex.Message);
            }
        }

    }
}
