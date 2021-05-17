using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    class Sender
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            {
                channel.QueueDeclare("WWII", false, false, false, null);

                string message = "Hitler's is about to send troops to Stanlingrad";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "WWII", null, body);
                Console.WriteLine($"Sent message - {message} ");
            }

            Console.WriteLine("Press [enter] to exit the sender app...");
            Console.ReadLine();
        }
    }
}
