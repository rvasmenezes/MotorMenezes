using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Entities;
using MotorMenezes.Domain.Aggregates.MotorcycleAgg.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace MotorMenezes.Domain.Host
{
    public class QueueConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public QueueConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "admin"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ConsumeMessage("add_motorcycle", ProcessMessage);

            return Task.CompletedTask;
        }

        public void ConsumeMessage(string queueName, Action<string> handleMessage)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                handleMessage(message);
            };

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private void ProcessMessage(string message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _motorcycleServices = scope.ServiceProvider.GetRequiredService<IMotorcycleServices>();

                var messageObject = JsonSerializer.Deserialize<Motorcycle>(message);

                if (messageObject != null)
                    _ = _motorcycleServices.Add(messageObject);
            }
        }
    }
}
