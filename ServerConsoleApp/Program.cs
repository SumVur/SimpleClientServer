using System;
using ServerConsoleApp.Controller;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ServerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainController().Start();
            Console.ReadKey();
        }
    }
}
