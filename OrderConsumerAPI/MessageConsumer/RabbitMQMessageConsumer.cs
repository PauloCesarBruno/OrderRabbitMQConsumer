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
                CellConcertOrder ord = JsonSerializer.Deserialize<CellConcertOrder>(content);
                ProcessMessages(ord).GetAwaiter().GetResult();
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume("Orderqueue", false, consumer);
            return Task.CompletedTask;
        }
        private async Task ProcessMessages(CellConcertOrder ord)
        {
            CellConcertOrder msg = new()
            {
                Id = ord.Id,
                DataEntrada = ord.DataEntrada,
                MarcaAparelho = ord.MarcaAparelho,
                ModeloAparelho = ord.ModeloAparelho,
                Reparado = ord.Reparado,
                ValorConserto = ord.ValorConserto,
            };

            await _repository.AddOrder(msg);
        }
    }
}
