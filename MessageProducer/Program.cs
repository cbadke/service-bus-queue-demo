using Microsoft.ServiceBus.Messaging;
using System;

namespace MessageProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine($"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} [connectionString] [queueName] [message]");
                return;
            }

            var connectionString = args[0];
            var queueName = args[1];
            var message = args[2];


            var client = QueueClient.CreateFromConnectionString(connectionString, queueName, ReceiveMode.PeekLock);

            var queueMessage = new BrokeredMessage(message);

            client.Send(queueMessage);

            return;
        }
    }
  
}
