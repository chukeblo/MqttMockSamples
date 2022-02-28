using MQTTnet;
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

            mqttServer.ClientConnectedHandler = new MqttServerClientConnectedHandlerDelegate(new Action<EventArgs>(e =>
            {
                this.currentConnectionStatusLabel.BeginInvoke(new Action(() => 
                {
                    this.currentConnectionStatusLabel.Text = "Connected";
                }));
            }));

            mqttServer.ClientDisconnectedHandler = new MqttServerClientDisconnectedHandlerDelegate(new Action<EventArgs>(e =>
            {
                this.currentConnectionStatusLabel.BeginInvoke(new Action(() =>
                {
                    this.currentConnectionStatusLabel.Text = "Disconnected";
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
