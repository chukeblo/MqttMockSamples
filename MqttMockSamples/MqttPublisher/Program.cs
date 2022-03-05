using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using OpenSSL.X509Certificate2Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace MqttPublisher
{
    class Program
    {
        private static IMqttClient client;
        private static IMqttClientOptions options;

        private static RootCATrust rootCATrust;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Publisher...");
            try
            {
                var mqttFactory = new MqttFactory();

                var deviceCertificateString = File.ReadAllText(
                    MqttConstants.CertsDirPath + MqttConstants.DeviceCertificateFileName);
                var privateKeyString = File.ReadAllText(
                    MqttConstants.CertsDirPath + MqttConstants.PrivateKeyFileName);
                var rootCAString = File.ReadAllText(
                    MqttConstants.CertsDirPath + MqttConstants.RootCAFileName);

                ICertificateProvider certProvider = new CertificateFromFileProvider(
                    deviceCertificateString, privateKeyString, true);
                var deviceCertificate = certProvider.Certificate;

                var certBytes = Encoding.UTF8.GetBytes(rootCAString);
                var signingCert = new X509Certificate2(certBytes);

                rootCATrust = new RootCATrust();
                rootCATrust.AddCert(signingCert);

                var certs = new List<X509Certificate>
                {
                    signingCert, deviceCertificate
                };

                var tlsOptions = new MqttClientOptionsBuilderTlsParameters();
                tlsOptions.Certificates = certs;
                tlsOptions.SslProtocol = SslProtocols.Tls12;
                tlsOptions.UseTls = true;
                tlsOptions.AllowUntrustedCertificates = true;
                tlsOptions.CertificateValidationHandler += rootCATrust.VerifyServerCertificate;

                client = mqttFactory.CreateMqttClient();
                options = new MqttClientOptionsBuilder()
                    .WithClientId(MqttConstants.ClientId)
                    .WithTcpServer(MqttConstants.Host, MqttConstants.Port)
                    .WithTls(tlsOptions)
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
            var floatValues = new List<float>
            {
                10.34f, 12.53f, 24.54f, 18.88f, 21.54f
            };

            var jsonDictionaries = new List<Dictionary<string, object>>();
            foreach (var val in floatValues)
            {
                var jsonDictionary = new Dictionary<string, object>
                {
                    [JsonConstants.TimeKey] = DateTime.Now.ToString(),
                    [JsonConstants.TemperatureKey] = val.ToString(),
                    [JsonConstants.HumidityKey] = (val + 2.0f).ToString()
                };
                jsonDictionaries.Add(jsonDictionary);
            }

            var messages = new List<string>();
            foreach (var dic in jsonDictionaries)
            {
                var json = JsonSerializer.Serialize(dic);
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("test")
                    .WithPayload(json)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();
                if (client.IsConnected)
                {
                    Console.WriteLine($"publishing message. payload = {json}");
                    client.PublishAsync(message);
                    Thread.Sleep(1000);
                }
            }
        }

        internal class RootCATrust
        {
            X509Certificate2Collection certificates;
            internal RootCATrust()
            {
                certificates = new X509Certificate2Collection();
            }

            internal void AddCert(X509Certificate2 certificate)
            {
                certificates.Add(certificate);
            }

            internal bool VerifyServerCertificate(MqttClientCertificateValidationCallbackContext context)
                => VerifyServerCertificate(new object(), context.Certificate, context.Chain, context.SslPolicyErrors);

            internal bool VerifyServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }
                var newChain = new X509Chain();
                var testChain = chain;

                testChain.ChainPolicy.ExtraStore.AddRange(certificates);
                testChain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
                testChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                var buildResult = testChain.Build(new X509Certificate2(certificate));

                if (buildResult)
                {
                    return true;
                }

                foreach (var status in testChain.ChainStatus)
                {
                    if (status.Status != X509ChainStatusFlags.UntrustedRoot)
                    {
                        return false;
                    }
                }

                foreach (var chainElement in testChain.ChainElements)
                {
                    foreach (var chainStatus in chainElement.ChainElementStatus)
                    {
                        if (chainStatus.Status == X509ChainStatusFlags.UntrustedRoot)
                        {
                            var foundCertificate = certificates.Find(X509FindType.FindByThumbprint, chainElement.Certificate.Thumbprint, false);
                            if (foundCertificate.Count == 0)
                            {
                                return false;
                            }
                        }
                    }
                }

                return true;
            }
        }
    }
}
