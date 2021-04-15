using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDal.Models
{
   public class SystemInfo
    {

        public int Id { get; set; }
        public string MachineName { get; set; }
        public string TimeZoneInfo { get; set; }

        public string OSInfo { get; set; }

        public string Version { get; set; }
        public string Ip { get; set; }
    }
}
