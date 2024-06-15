using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MotorMenezes.Core.Helpers;
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

            using (var scope = _serviceProvider.CreateScope())
            {
                var _globalVariables = scope.ServiceProvider.GetRequiredService<GlobalVariables>();
                
                var factory = new ConnectionFactory()
                {
                    HostName = _globalVariables.RabbitMQHostName,
                    Port = _globalVariables.RabbitMQPort,
                    UserName = _globalVariables.RabbitMQUserName,
                    Password = _globalVariables.RabbitMQPassword
                };

                _connection = factory.CreateConnection();
            }

            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            ConsumeMessage("add_motorcycle", ProcessMessageAsync);

            return Task.CompletedTask;
        }

        public void ConsumeMessage(string queueName, Func<string, Task> handleMessage)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                await Task.Run(() => handleMessage(message));
            };

            _channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private async Task ProcessMessageAsync(string message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _motorcycleServices = scope.ServiceProvider.GetRequiredService<IMotorcycleServices>();

                var messageObject = JsonSerializer.Deserialize<Motorcycle>(message);

                if (messageObject != null)
                    await _motorcycleServices.Add(messageObject);
            }
        }
    }
}
