using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;

namespace ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainController().Start();
            Console.ReadLine();
        }
    }
}
