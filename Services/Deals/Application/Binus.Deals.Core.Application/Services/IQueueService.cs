using System.Threading.Tasks;

namespace Binus.Deals.Core.Application.Services;

public interface IQueueService
{
    Task SendQueueAsync(string topic, object message);
}