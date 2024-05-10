using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public interface IQueueService
    {
        void PublishMessageToQueue(string queueName, string message);
        string ConsumeMessageFromQueue(string queueName);
    }
}
