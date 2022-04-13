using Artsec.TopicsMonitor.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Artsec.TopicsMonitor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string? _serverIp;
        private string? _topic;
        private string? _currentTopic;
        private string? _topicMessage;
        private bool _isSubscribeEnable;


        public string? _label510DeviceVersion;
        public string? _label511DeviceVersion;
        public string? _label513DeviceVersion;
        public string? _label514DeviceVersion;

        public string? _labelOver2_1;
        public string? _labelOver2_2;
        public string? _labelOver2_3;
        public string? _labelOver2_4;

        public string? _label510LastOn;
        public string? _label511LastOn;
        public string? _label513LastOn;
        public string? _label514LastOn;

        public string? _label510LastOff;
        public string? _label511LastOff;
        public string? _label513LastOff;
        public string? _label514LastOff;

        public string? _label510Status;
        public string? _label511Status;
        public string? _label513Status;
        public string? _label514Status;

        private Settings _settings;
        private MainWindowModel _model;


        public MainWindowViewModel(Settings settings)
        {
            _model = new MainWindowModel();
            _model.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;

            _settings = settings;
            ServerIp = settings.ServerIp;
            Topic = settings.Topic;

            SaveSettingsCommand = new DelegateCommand(SaveSettings);
            UpdateServerIpCommand = new DelegateCommand(UpdateServerIp);
            UpdateTopicCommand = new DelegateCommand(UpdateTopic);
        }
        public bool IsSubscribeEnable
        {
            get { return _isSubscribeEnable; }
            set { SetProperty(ref _isSubscribeEnable, value); }
        }

        public string? ServerIp
        {
            get { return _serverIp; }
            set { SetProperty(ref _serverIp, value); }
        }
        public string? Topic
        {
            get { return _topic; }
            set { SetProperty(ref _topic, value); }
        }
        public string? TopicMessage
        {
            get { return _topicMessage; }
            set { SetProperty(ref _topicMessage, value); }
        }

        public string? label510DeviceVersion
        {
            get { return _label510DeviceVersion; }
            set { SetProperty(ref _label510DeviceVersion, value); }
        }
        public string? label511DeviceVersion
        {
            get { return _label511DeviceVersion; }
            set { SetProperty(ref _label511DeviceVersion, value); }
        }
        public string? label513DeviceVersion
        {
            get { return _label513DeviceVersion; }
            set { SetProperty(ref _label513DeviceVersion, value); }
        }
        public string? label514DeviceVersion
        {
            get { return _label514DeviceVersion; }
            set { SetProperty(ref _label514DeviceVersion, value); }
        }
        
        public string? labelOver2_1
        {
            get { return _labelOver2_1; }
            set { SetProperty(ref _labelOver2_1, value); }
        }        
        public string? labelOver2_2
        {
            get { return _labelOver2_2; }
            set { SetProperty(ref _labelOver2_2, value); }
        }        
        public string? labelOver2_3
        {
            get { return _labelOver2_3; }
            set { SetProperty(ref _labelOver2_3, value); }
        }        
        public string? labelOver2_4
        {
            get { return _labelOver2_4; }
            set { SetProperty(ref _labelOver2_4, value); }
        }

        public string? label510LastOn
        {
            get { return _label510LastOn; }
            set { SetProperty(ref _label510LastOn, value); }
        }
        public string? label511LastOn
        {
            get { return _label511LastOn; }
            set { SetProperty(ref _label511LastOn, value); }
        }
        public string? label513LastOn
        {
            get { return _label513LastOn; }
            set { SetProperty(ref _label513LastOn, value); }
        }
        public string? label514LastOn
        {
            get { return _label514LastOn; }
            set { SetProperty(ref _label514LastOn, value); }
        }

        public string? label510LastOff
        {
            get { return _label510LastOff; }
            set { SetProperty(ref _label510LastOff, value); }
        }
        public string? label511LastOff
        {
            get { return _label511LastOff; }
            set { SetProperty(ref _label511LastOff, value); }
        }
        public string? label513LastOff
        {
            get { return _label513LastOff; }
            set { SetProperty(ref _label513LastOff, value); }
        }
        public string? label514LastOff
        {
            get { return _label514LastOff; }
            set { SetProperty(ref _label514LastOff, value); }
        }

        public string? label510Status
        {
            get { return _label510Status; }
            set { SetProperty(ref _label510Status, value); }
        }
        public string? label511Status
        {
            get { return _label511Status; }
            set { SetProperty(ref _label511Status, value); }
        }
        public string? label513Status
        {
            get { return _label513Status; }
            set { SetProperty(ref _label513Status, value); }
        }
        public string? label514Status
        {
            get { return _label514Status; }
            set { SetProperty(ref _label514Status, value); }
        }


        public DelegateCommand SaveSettingsCommand { get; private set; }
        public DelegateCommand UpdateServerIpCommand { get; private set; }
        public DelegateCommand UpdateTopicCommand { get; private set; }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            MessageBox.Show(e.Message.ToString());
        }

        //private async void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs a)
        //{
        //    var message = Encoding.UTF8.GetString(a.Message);
        //    var date = DateTime.Now;

        //    String label;
        //    switch (a.Topic)
        //    {
        //        case "root/artonit/Over2_here":
        //            Application.Current.Dispatcher.InvokeAsync(() =>
        //            {
        //                labelOver2_1 = message + "\n" + "\n" + "T" + date;
        //                labelOver2_2 = message + "\n" + "\n" + "T" + date;
        //                labelOver2_3 = message + "\n" + "\n" + "T" + date;
        //                labelOver2_4 = message + "\n" + "\n" + "T" + date;

        //            });

        //            return;
        //        case "root/artonit/510/DeviceVersion":
        //            label = _label510DeviceVersion;
        //            break;
        //        case "root/artonit/511/DeviceVersion":
        //            label = _label511DeviceVersion;
        //            break;
        //        case "root/artonit/513/DeviceVersion":
        //            label = label513DeviceVersion;
        //            break;
        //        case "root/artonit/514/DeviceVersion":
        //            label = label514DeviceVersion;
        //            break;
        //        case "root/artonit/510/LastEvtAPonline":
        //            label = label510LastOn;
        //            break;
        //        case "root/artonit/511/LastEvtAPonline":
        //            label = label511LastOn;
        //            break;
        //        case "root/artonit/513/LastEvtAPonline":
        //            label = label513LastOn;
        //            break;
        //        case "root/artonit/514/LastEvtAPonline":
        //            label = label514LastOn;
        //            break;
        //        case "root/artonit/510/LastEvtAPoffline":
        //            label = label510LastOff;
        //            break;
        //        case "root/artonit/511/LastEvtAPoffline":
        //            label = label511LastOff;
        //            break;
        //        case "root/artonit/513/LastEvtAPoffline":
        //            label = label513LastOff;
        //            break;
        //        case "root/artonit/514/LastEvtAPoffline":
        //            label = label514LastOff;
        //            break;
        //        default:
        //            break;
        //    }

        //    label.Dispatcher.Invoke(new Action(delegate
        //    {
        //        label.Content = message + "\n" + "T" + date;
        //    }));
        //}

        //private void Invoke(MethodInvoker methodInvoker)
        //{
        //    throw new NotImplementedException();
        //}

        private void SaveSettings()
        {
            _settings.ServerIp = ServerIp;
            _settings.Topic = Topic;
            _settings.Save();
            MessageBox.Show("Настройки сохранены");
        }
        private void UpdateServerIp()
        {
            if (ServerIp != null)
            {
                _model.ServerIp = ServerIp;
                IsSubscribeEnable = true;
            }
        }
        private void UpdateTopic()
        {
            if (Topic != null)
            {
                _model.Topic = Topic;
            }
        }
    }
}
