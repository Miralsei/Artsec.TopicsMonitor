using Artsec.TopicsMonitor.Views;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Artsec.TopicsMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        private Settings _settings;
        private const string SettingsBasePath = "C:\\ProgramData\\nast";
        private const string SettingsFileName = "nast.json";
        protected override Window CreateShell()
        {
            

            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            CheckAndCreateSettings();
            ReadSettings();
            containerRegistry.RegisterInstance<Settings>(_settings);
        }
        private void CheckAndCreateSettings()
        {
            if (!Directory.Exists(SettingsBasePath))
            {
                Directory.CreateDirectory(SettingsBasePath);
            }
            if (!File.Exists(SettingsBasePath + "\\" + SettingsFileName))
            {
                File.Copy(SettingsFileName, SettingsBasePath + "\\" + SettingsFileName);
            }
        }
        private void ReadSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(SettingsBasePath)
                .AddJsonFile(SettingsFileName, optional: false, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            _settings = new Settings
            {
                SettingsPath = SettingsBasePath + "\\" + SettingsFileName,
                ServerIp = configuration.GetSection("ServerIp").Value,
                Topic = configuration.GetSection("Topic").Value,
            };
        }
    }
}
