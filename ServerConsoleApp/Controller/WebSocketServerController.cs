using System;
using System.Collections.Generic;
using System.Text;
using ServerConsoleApp.Behavior;
using WebSocketSharp.Server;

namespace ServerConsoleApp.Controller
{

    public class WebSocketServerController
    {
        private WebSocketServer Server;
        public WebSocketServerController(string ServerUrl)
        {
            this.Server = new WebSocketServer(ServerUrl);
            this.Server.AddWebSocketService<MainBehavior>("/");
        }
        public void Start()
        {
            this.Server.Start();
            Console.WriteLine("Server start on ws://127.0.0.1:8888");
        }
        public void Stop()
        {
            this.Server.Stop();
        }

    }
}
