using System;
using System.Collections.Generic;
using System.Text;
using ClientConsoleAppinterface;
using WebSocketSharp;

namespace ClientConsoleApp.Controller
{
   public class WebSocketClientController
    {
        private WebSocket WS;
        private ClientServerCommunicationInterface clientServerCommunication;
        public Action Action;
        public Dictionary<string, Func<string>> Events { get; set; }
        public WebSocketClientController(string ServerUrl, ClientServerCommunicationInterface CSC)
        {
            this.clientServerCommunication = CSC;
            this.Events = this.clientServerCommunication.GetEvents();
            this.WS = new WebSocket(ServerUrl);
            this.WS.OnOpen += WS_OnOpen;
            this.WS.OnMessage += WS_OnMessage;
            
        }

        private void WS_OnMessage(object sender, MessageEventArgs e)
        {
            Send(this.clientServerCommunication.MessageAnalytics(e.Data));
        }

        private void WS_OnOpen(object sender, EventArgs e)
        {
            Console.WriteLine("WebSocket Connection is open");
            Send(Events["Connect"].Invoke());
        }

        public void Connect()
        {
                try
                {
                this.WS.Connect();
                }
                catch (Exception date)
                {
                    Console.WriteLine(date);
                }
        }
        public void Send(string massage)
        {
            
            if (this.WS.IsAlive)
            {
                try
                {
                    this.WS.Send(massage);
                }
                catch (Exception date)
                {
                    Console.WriteLine(date);
                }
            }
        }
        public void Close()
        {
            Console.WriteLine("WebSocket Connection is close");
            this.WS.Close();
        }
    }
}
