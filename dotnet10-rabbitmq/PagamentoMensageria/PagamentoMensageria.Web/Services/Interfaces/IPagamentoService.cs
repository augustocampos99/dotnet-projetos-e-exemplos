using PagamentoMensageria.Web.Entities;

namespace PagamentoMensageria.Web.Services.Interfaces
{
    public interface IPagamentoService
    {
        Task<bool> SendMessage(Pagamento pagamento);
    }
}
