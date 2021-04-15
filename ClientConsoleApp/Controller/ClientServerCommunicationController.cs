using System;
using System.Collections.Generic;
using System.Text;
using CipherManager;
using ClientConsoleApp.Models;
using ClientConsoleAppinterface;
using Newtonsoft.Json;

namespace ClientConsoleApp.Controller
{
    public class ClientServerCommunicationController : ClientServerCommunicationInterface
    {
        private CipherManagerController CipherManager;
        private Dictionary<string, Func<string>> Events;
        private SystemInfo SystemInfo;
        public ClientServerCommunicationController()
        {
            this.SystemInfo = new SystemInfo();
            this.CipherManager = new CipherManagerController();
            this.Events = new Dictionary<string, Func<string>>();
            Events.Add("Connect",()=> { return ConnectContent(); });
            
        }
        public Dictionary<string, Func<string>> GetEvents()
        {
            return Events;
        }
        public string ConnectContent()
        {
            
            string date=JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {
                    "Date",
                    this.CipherManager.Encrypt(
                                            JsonConvert.SerializeObject(new Dictionary<string, string>
                                            {
                                                { "IpConnect",this.SystemInfo.Ip  }
                                            }))
                }
            });
            this.CipherManager.key = this.SystemInfo.Ip;
            return date;
        }
        public string MessageAnalytics(string massage)
        {
            if (massage != null)
            {
                Dictionary<string, string> date = JsonConvert.DeserializeObject<Dictionary<string, string>>(massage);
                foreach (var item in date)
                {
                    switch (item.Key)
                    {
                        case "Key":
                            {
                                this.CipherManager.key= this.CipherManager.Decrypt(item.Value) + this.SystemInfo.Ip;
                                return InfoContent();
                                
                            }
                        case "Request":
                            {
                                if(item.Value=="Get")
                                {
                                    return InfoContent();
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
             }
            return "";
        }

        public string InfoContent()
        {
            return JsonConvert.SerializeObject(new Dictionary<string, string>
            {
                {
                    "Date",this.CipherManager.Encrypt(this.SystemInfo.GetInfo())
                }
            });
        }
    }
}
