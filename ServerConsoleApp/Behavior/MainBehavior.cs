using System;
using System.Collections.Generic;
using System.Text;
using CipherManager;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
using ServerConsoleBLL.Controller;

namespace ServerConsoleApp.Behavior
{
   public class MainBehavior:WebSocketBehavior
    {
        private MainController MainController;
        public MainBehavior()
        {
            this.MainController = new MainController();
            this.MainController.GetWebSocketKey += () => { return Context.SecWebSocketKey; };
            this.MainController.Send += (string massage, string Type) => { send(massage,Type); };
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            MessageAnalytics(e.Data);
        }
        public void send(string massage,string Type)
        {
            string Date;
            switch (Type)
            {
                case "Key":
                    {
                        Date= JsonConvert.SerializeObject(new Dictionary<string, string>
                        {
                            {
                                "Key",massage
                            }
                        });
                        break;
                    }
                case "Request":
                    {
                        Date = JsonConvert.SerializeObject(new Dictionary<string, string>
                        {
                            {
                                "Request",massage
                            }
                        });
                        break;
                    }
                default:
                    {
                        Date = null;
                    }
                    break;
            }
            Send(Date);
        }
        public void MessageAnalytics(string massage)
        {
            Dictionary<string, string> date = JsonConvert.DeserializeObject<Dictionary<string, string>>(massage);
            if (date.ContainsKey("Date"))
            {
                this.MainController.MessageAnalytics(date["Date"]);
            }
        }
    }
}
