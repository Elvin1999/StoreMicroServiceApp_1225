using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQService
{
    public class QueueService : IQueueService
    {
        private string _url = "amqps://hkqqhlch:b5wm2yEAKLpohoWau42wJvRQNWOBORWt@chimpanzee.rmq.cloudamqp.com/hkqqhlch";
        public string ConsumeMessageFromQueue(string queueName)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri(_url);
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);

            var consumer = new EventingBasicConsumer(channel);

            var data = channel.BasicGet(queueName, false);
            var returnedResult=Encoding.UTF8.GetString(data.Body.ToArray());
            return returnedResult;
        }

        public void PublishMessageToQueue(string queueName, string message)
        {

            var factory = new ConnectionFactory();
            factory.Uri = new Uri(_url);
            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, true, false, false);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", queueName, null, body);
        }
    }
}
