using PagamentoMensageria.Consumer.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;

Console.WriteLine("Consumindo mensagens do RabbitMQ");


var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest",
};

var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

// FILA
await channel.QueueDeclareAsync(
    queue: "dotnet10-pagamentos",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null
);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (sender, ea) =>
{
    var body = ea.Body.ToArray();
    var message = JsonSerializer.Deserialize<PagamentoMessage>(Encoding.UTF8.GetString(body));
    Console.WriteLine($"---------------------------------------------------------------------------------------");
    Console.WriteLine($"Mensagem recebida: {message.Id}");
    Console.WriteLine($"Cliente: {message.NomePagador}");
    Console.WriteLine($"Cartão: {message.NumeroCartao}");
    Console.WriteLine($"CVV: {message.DigitoVerificador}");
    Console.WriteLine($"Validade: {message.MesVencimento}/{message.AnoVencimento}");
    Console.WriteLine($"Valor: {message.Valor}");
    Console.WriteLine($"---------------------------------------------------------------------------------------");

    // Simulando mensagem assincrona (delay de 3s)
    await Task.Delay(3000);

    // Manual ACK (optional but recommended)
    await channel.BasicAckAsync(ea.DeliveryTag, multiple: false);
};

// Iniciando consumo
await channel.BasicConsumeAsync(
    queue: "dotnet10-pagamentos",
    autoAck: false,
    consumer: consumer
);


Console.WriteLine("Aguardando mensagens. Pressione [Enter] para sair.");
Console.ReadLine();

