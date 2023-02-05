using System.Text;
using System.Threading.Tasks;
using Binus.Deals.Core.Application.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Binus.Deals.Core.Infrastructure.Services;

public class QueueService : IQueueService
{
    public async Task SendQueueAsync(string topic, object message)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5674
        };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        channel.QueueDeclare(queue:topic,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var content = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(content);

        channel.BasicPublish(exchange: string.Empty,
            routingKey: topic,
            basicProperties: null,
            body: body);
    }
}