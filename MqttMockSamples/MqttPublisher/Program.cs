using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Text;
using System.Threading;

namespace MqttPublisher
{
    class Program
    {
        private static IMqttClient client;
        private static IMqttClientOptions options;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Publisher...");
            try
            {
                client = new MqttFactory().CreateMqttClient();
                options = new MqttClientOptionsBuilder()
                    .WithClientId("PublisherId")
                    .WithTcpServer("localhost", 1884)
                    .WithCredentials("bud", "%spenser%")
                    .WithCleanSession()
                    .Build();

                client.UseConnectedHandler(e =>
                {
                    Console.WriteLine("Connected successfully with MQTT broker");

                });

                client.UseDisconnectedHandler(e =>
                {
                    Console.WriteLine("Disconnected from MQTT broker");
                });

                client.UseApplicationMessageReceivedHandler(e =>
                {
                    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                    Console.WriteLine($"- Topic = {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"- Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                    Console.WriteLine($"- QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                    Console.WriteLine($"- Retain = {e.ApplicationMessage.Retain}");
                    Console.WriteLine();
                });

                client.ConnectAsync(options).Wait();
                Console.WriteLine("Press any key to start publish simulation");
                Console.ReadLine();
                SimulatePublish();

                Console.WriteLine("Simulation ended");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SimulatePublish()
        {
            var counter = 0;
            while (counter++ < 10)
            {
                var testMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("test")
                    .WithPayload($"Payload = {counter}")
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                if (client.IsConnected)
                {
                    Console.WriteLine($"publishing at {DateTime.UtcNow}");
                    client.PublishAsync(testMessage);
                }
                Thread.Sleep(2000);
            }
        }
    }
}
