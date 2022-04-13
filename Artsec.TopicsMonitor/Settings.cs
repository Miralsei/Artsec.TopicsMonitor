using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Artsec.TopicsMonitor
{
    public class Settings
    {
        [JsonIgnore]
        public string? SettingsPath { get; set; }
        public string? ServerIp { get; set; }
        public string? Topic { get; set; }

        public string? label510DeviceVersion { get; set; }
        public string? label511DeviceVersion { get; set; }
        public string? label513DeviceVersion { get; set; }
        public string? label514DeviceVersion { get; set; }

        public string? labelOver2_1 { get; set; }
        public string? labelOver2_2 { get; set; }
        public string? labelOver2_3 { get; set; }
        public string? labelOver2_4 { get; set; }

        public string? label510LastOn { get; set; }
        public string? label511LastOn { get; set; }
        public string? label513LastOn { get; set; }
        public string? label514LastOn { get; set; }

        public string? label510LastOff { get; set; }
        public string? label511LastOff { get; set; }
        public string? label513LastOff { get; set; }
        public string? label514LastOff { get; set; }

        public string? label510Status { get; set; }
        public string? label511Status { get; set; }
        public string? label513Status { get; set; }
        public string? label514Status { get; set; }

        internal void Save()
        {
            if (SettingsPath != null)
            {
                File.WriteAllText(SettingsPath, JsonSerializer.Serialize(this));
            }
        }
    }
}
