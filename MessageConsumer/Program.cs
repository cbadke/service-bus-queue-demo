using Microsoft.ServiceBus.Messaging;
using System;

namespace MessageConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine($"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} [connectionString] [accessToken]");
                return;
            }

            var connectionString = args[0];
            var queueName = args[1];

            
            var client = QueueClient.CreateFromConnectionString(connectionString, queueName, ReceiveMode.PeekLock);

            client.OnMessage( (queueMessage) =>
            {
                var message = queueMessage.GetBody<string>();

                Console.WriteLine(message);
            });



            System.Threading.Thread.Sleep(Int32.MaxValue);
        }
    }
}
