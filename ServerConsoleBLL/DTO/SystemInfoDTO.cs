using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsoleBLL.DTO
{
   public class SystemInfoDTO
    {
        public string MachineName { get; set; }
        public string TimeZoneInfo { get; set; }

        public string OSInfo { get; set; }

        public string Version { get; set; }
        public string Ip { get; set; }
    }
}
