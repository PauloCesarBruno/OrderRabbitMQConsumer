using OrderConsumerAPI.Messages;
using OrderConsumerAPI.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace OrderConsumerAPI.MessageConsumer
{
    public class RabbitMQMessageConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQMessageConsumer(OrderRepository repository)
        {
            _repository = repository;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "Orderqueue", false, false, false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (chanel, evt) =>
            {
                var content = Encoding.UTF8.GetString(evt.Body.ToArray());
                Order ord = JsonSerializer.Deserialize<Order>(content);
                ProcessMessages(ord).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("Orderqueue", false, consumer);
            return Task.CompletedTask;
        }
        private async Task ProcessMessages(Order ord)
        {
            Order msg = new()
            {
                Id = ord.Id,
                DataRegistro = ord.DataRegistro,
                Nome = ord.Nome,
                CPF = ord.CPF,
                Email = ord.Email,
                Telefone = ord.Telefone,
                Cartao = ord.Cartao,
                NumeroCartao = ord.NumeroCartao,
                DataVencimento = ord.DataVencimento,
                CVV = ord.CVV,
            };
            await _repository.AddOrder(msg);
        }
    }
}
