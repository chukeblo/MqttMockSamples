using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Linq;
using System.Text;

namespace MqttBroker
{
    class Program
    {
        private static int MessageCounter = 0;

        static void Main(string[] args)
        {
            MqttServerOptionsBuilder options = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .WithConnectionValidator(c =>
                {
                    Console.WriteLine($"{c.ClientId} connection validator for c.Endpoint: {c.Endpoint}");
                    c.ReasonCode = MqttConnectReasonCode.Success;
                })
                .WithApplicationMessageInterceptor(c =>
                {
                    Console.WriteLine("WithApplicationMessageIntercepter block merging data");
                    var newData = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
                    var oldData = c.ApplicationMessage.Payload;
                    var mergedData = newData.Concat(oldData).ToArray();
                    c.ApplicationMessage.Payload = mergedData;
                })
                .WithConnectionBacklog(100)
                .WithDefaultEndpointPort(1884);

            var mqttServer = new MqttFactory().CreateMqttServer();
            mqttServer.StartAsync(options.Build()).Wait();

            Console.WriteLine("Broker is Running.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            mqttServer.StopAsync().Wait();
        }
    }
}
