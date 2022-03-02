using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using System;
using System.Text;

namespace MqttReceiver
{
    class Program
    {
        private static IMqttClient client;
        private static IMqttClientOptions options;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting publisher");
            try
            {
                var factory = new MqttFactory();
                client = factory.CreateMqttClient();

                options = new MqttClientOptionsBuilder()
                    .WithClientId("TestReceiver")
                    .WithTcpServer("localhost", 1884)
                    .WithCredentials("bud", "%spencer%")
                    .WithCleanSession()
                    .Build();
                client.UseConnectedHandler(e =>
                {
                    Console.WriteLine("Connected successfully with MQTT broker");
                    client.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("test").Build());
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

                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
