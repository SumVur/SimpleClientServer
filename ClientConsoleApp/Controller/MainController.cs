using System;
using System.Collections.Generic;
using System.Text;
using ClientConsoleApp.Controller;
using WebSocketSharp;
using CipherManager;
using ClientConsoleApp.Models;
using Newtonsoft.Json;

namespace ClientConsoleApp
{
   public class MainController
    {
        private WebSocketClientController WSCC;
        public MainController(string ServerUrl= "ws://127.0.0.1:8888/")
        {
            
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Console.CancelKeyPress += Console_CancelKeyPress;
            this.WSCC = new WebSocketClientController(ServerUrl,new ClientServerCommunicationController());
        }

        public void Start()
        {
            this.WSCC.Connect();
        }

        private void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {

            this.WSCC.Close();
        }

        void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            this.WSCC.Close();
        }
    }
}
