using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CipherManager;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using ServerConsoleBLL.DTO;
using ServerDal.Repositories;

namespace ServerConsoleBLL.Controller
{
   public class MainController
    {
        private CipherManagerController CipherManager;
         public event Func<string> GetWebSocketKey;
        public event Action<string,string> Send;
        private SystemInfoRepository infoRepository;
        public MainController()
        {
            this.CipherManager = new CipherManagerController();
           this.infoRepository = new SystemInfoRepository();
            int num = 0;
            TimerCallback tm = new TimerCallback((s)=> { this.Send?.Invoke("Get", "Request");});
            Timer timer = new Timer(tm, num, 0,300000);
        }
        public void MessageAnalytics(string Date)
        {
            Dictionary<string, string> date = JsonConvert.DeserializeObject<Dictionary<string, string>>(this.CipherManager.Decrypt(Date));
                foreach (var item in date)
                {
                    switch (item.Key)
                    {
                        case "IpConnect":
                            {
                                string WebSocketKey = GetWebSocketKey?.Invoke();
                                if (WebSocketKey != null)
                                {
                                    this.CipherManager.key = item.Value;
                                    this.Send?.Invoke(this.CipherManager.Encrypt(WebSocketKey), "Key");
                                    this.CipherManager.key = WebSocketKey + item.Value;
                                   
                                }
                                break;
                            }
                             default:
                        Console.WriteLine(item);
                            break;
                    }
                }
                if(date.ContainsKey("Machine_Name")&&
                date.ContainsKey("Time_Zone_Info")&&
                date.ContainsKey("OS_Info") &&
                date.ContainsKey("Version") &&
                date.ContainsKey("Ip"))
                {
                SaveDate(new SystemInfoDTO { Ip= date["Ip"],
                                             MachineName=date["Machine_Name"],
                                              OSInfo=date["OS_Info"],
                                               TimeZoneInfo=date["Time_Zone_Info"],
                                                Version=date["Version"]
                });
                }
        }
        private void  SaveDate(SystemInfoDTO systemInfo)
        {
            if (this.infoRepository.GetByIp(systemInfo.Ip) != null)
            {
                if((this.infoRepository.GetByIp(systemInfo.Ip).MachineName!=systemInfo.MachineName)||
                    (this.infoRepository.GetByIp(systemInfo.Ip).OSInfo != systemInfo.OSInfo)||
                    (this.infoRepository.GetByIp(systemInfo.Ip).TimeZoneInfo != systemInfo.TimeZoneInfo) ||
                    (this.infoRepository.GetByIp(systemInfo.Ip).Version != systemInfo.Version))
                {
                    this.infoRepository.Add(new ServerDal.Models.SystemInfo { Ip = systemInfo.Ip, MachineName = systemInfo.MachineName, OSInfo = systemInfo.OSInfo, TimeZoneInfo = systemInfo.TimeZoneInfo, Version = systemInfo.Version });
                }

            }
            else
            {
                this.infoRepository.Add(new ServerDal.Models.SystemInfo { Ip=systemInfo.Ip, MachineName=systemInfo.MachineName, OSInfo=systemInfo.OSInfo, TimeZoneInfo=systemInfo.TimeZoneInfo, Version=systemInfo.Version });
            }
        }
    }
}
