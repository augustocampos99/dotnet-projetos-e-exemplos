using System;
using System.Collections.Generic;
using System.Text;

namespace PagamentoMensageria.Consumer.Entities
{
    public class PagamentoMessage
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
