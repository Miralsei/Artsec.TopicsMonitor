using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using static uPLibrary.Networking.M2Mqtt.MqttClient;

namespace Artsec.TopicsMonitor.Models
{
    internal class MainWindowModel
    {
        private MqttClient _mqttClient;
        private string _serverIp;
        private string _topic;

        public MainWindowModel()
        {
        }

        public event MqttMsgPublishEventHandler MqttMsgPublishReceived;

        public string ServerIp
        {
            get { return _serverIp; }
            set
            {
                _serverIp = value;
                if (_mqttClient?.IsConnected == true)
                {
                    _mqttClient.Disconnect();
                }
                _mqttClient = new MqttClient(ServerIp);
                _mqttClient.Connect("510");
                _mqttClient.MqttMsgPublishReceived += MqttMsgPublishReceived;
            }
        }
        public string Topic
        {
            get { return _topic; }
            set
            {
                //_mqttClient?.Unsubscribe(new string[] { _topic });
                _topic = value;
                _mqttClient.Subscribe(new string[] { _topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            }
        }
    }
}
