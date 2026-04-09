using PagamentoMensageria.Web.Entities;
using PagamentoMensageria.Web.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace PagamentoMensageria.Web.Services
{
    public class PagamentoService : IPagamentoService
    {

        public async Task <bool> SendMessage(Pagamento pagamento)
        {
            try
            {
                pagamento.Id = Guid.NewGuid();

                // Criando conexão
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };
                using var connection = await factory.CreateConnectionAsync();
                using var channel = await connection.CreateChannelAsync();

                // Declarando FILA
                await channel.QueueDeclareAsync(
                    queue: "dotnet10-pagamentos",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                // Serializando objeto
                string message = JsonSerializer.Serialize(pagamento);
                var body = Encoding.UTF8.GetBytes(message);

                // Publicando mensagem
                await channel.BasicPublishAsync(
                    exchange: "",
                    routingKey: "dotnet10-pagamentos",
                    body: body
                );

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
