using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ClientConsoleApp.Models;

namespace ClientConsoleApp
{
    class SystemInfo
    {
        public string Machine_Name { get; private set; }
        public string Time_Zone_Info { get; private set; }
        public string OS_Info { get; private set; }
        public string Version { get; private set; }
        public string Ip { get; private set; }

        public SystemInfo()
        {
            this.Machine_Name = Environment.MachineName;
            this.Time_Zone_Info = TimeZoneInfo.Local.ToString();
            this.OS_Info = Environment.OSVersion.ToString();
            this.Version = Environment.Version.ToString();
            this.Ip = new ClientIp().GetIp();
        }
        public string GetInfo()
        {
         
            return JsonSerializer.Serialize<SystemInfo>(this);

        }
    }
}
