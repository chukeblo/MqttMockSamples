using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Server;
using System;
using System.Windows.Forms;

namespace MqttServerApp
{
    public partial class Form1 : Form
    {
        private MqttServer mqttServer = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            StartServer();
        }


        private async void StartServer()
        {
            if (this.mqttServer == null)
            {
                var optionsBuilder = new MqttServerOptionsBuilder()
                                .WithDefaultEndpoint().WithDefaultEndpointPort(1883).WithSubscriptionInterceptor(c =>
                                {
                                    c.AcceptSubscription = true;
                                })
                                .WithApplicationMessageInterceptor(c =>
                                {
                                    c.AcceptPublish = true;
                                });

                mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;

                mqttServer.StartedHandler = new MqttServerStartedHandlerDelegate(new Action<EventArgs>(e =>
                {
                    this.currentConnectionStatusLabel.BeginInvoke(new Action(() =>
                    {
                        this.currentConnectionStatusLabel.Text = "Disconnected";
                    }));
                }));

                mqttServer.StoppedHandler = new MqttServerStoppedHandlerDelegate(new Action<EventArgs>(e =>
                {
                    this.currentConnectionStatusLabel.BeginInvoke(new Action(() =>
                    {
                        this.currentConnectionStatusLabel.Text = "Stopped";
                    }));
                }));

                mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(new Action<MqttServerClientConnectedEventArgs>(e =>
                {
                    this.currentConnectionStatusLabel.BeginInvoke(new Action(() =>
                    {
                        this.currentConnectionStatusLabel.Text = "Connected";
                    }));
                    this.logTextBox.BeginInvoke(new Action(() =>
                    {
                        this.logTextBox.Text += $"[ClientConnected] client id = {e.ClientId}, endpoint = {e.Endpoint}";
                    }));
                }));

                mqttServer.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(new Action<MqttServerClientDisconnectedEventArgs>(e =>
                {
                    this.currentConnectionStatusLabel.BeginInvoke(new Action(() =>
                    {
                        this.currentConnectionStatusLabel.Text = "Disconnected";
                    }));
                    this.logTextBox.BeginInvoke(new Action(() =>
                    {
                        this.logTextBox.Text += $"[ClientDisconnected] client id = {e.ClientId}, endpoint = {e.Endpoint}, disconnect type = {e.DisconnectType}";
                    }));
                }));

                mqttServer.ClientSubscribedTopicHandler = new MqttServerClientSubscribedTopicHandlerDelegate(new Action<MqttServerClientSubscribedTopicEventArgs>(e =>
                {
                    this.logTextBox.BeginInvoke(new Action(() =>
                    {
                        this.logTextBox.Text += $"[ClientSubscribedTopic] client id = {e.ClientId}, topic = {e.TopicFilter}";
                    }));
                }));

                mqttServer.ClientUnsubscribedTopicHandler = new MqttServerClientUnsubscribedTopicHandlerDelegate(new Action<MqttServerClientUnsubscribedTopicEventArgs>(e =>
                {
                    this.logTextBox.BeginInvoke(new Action(() =>
                    {
                        this.logTextBox.Text += $"[ClientUnsubscribedTopic] client id = {e.ClientId}, topic = {e.TopicFilter}";
                    }));
                }));

                mqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(new Action<MqttApplicationMessageReceivedEventArgs>(e =>
                {
                    this.logTextBox.BeginInvoke(new Action(() =>
                    {
                        this.logTextBox.Text += $"[ApplicationMessageReceived] client id = {e.ClientId}, topic = {e.ApplicationMessage.Topic}, payload = {e.ApplicationMessage.Payload}";
                    }));
                }));

                await mqttServer.StartAsync(optionsBuilder.Build());
                this.logTextBox.BeginInvoke(new Action(() =>
                {
                    this.logTextBox.Text += "MQTT Server is started." + Environment.NewLine;
                }));
            }
        }
    }
}
