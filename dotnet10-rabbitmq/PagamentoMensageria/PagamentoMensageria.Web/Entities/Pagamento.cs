namespace PagamentoMensageria.Web.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; }

        public string NomePagador { get; set; }

        public string NumeroCartao { get; set; }

        public int DigitoVerificador { get; set; }

        public int MesVencimento { get; set; }

        public int AnoVencimento { get; set; }

        public decimal Valor { get; set; }
    }
}
