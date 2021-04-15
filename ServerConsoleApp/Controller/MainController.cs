using System;
using System.Collections.Generic;
using System.Text;

namespace ServerConsoleApp.Controller
{
   public class MainController
    {
        private WebSocketServerController WSSC;
        public MainController()
        {
            this.WSSC = new WebSocketServerController("ws://127.0.0.1:8888");
        }
        public void Start()
        {
            this.WSSC.Start();
        }
        public void Stop()
        {
            this.WSSC.Stop();
        }
    }
}
