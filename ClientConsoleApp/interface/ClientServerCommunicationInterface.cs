using System;
using System.Collections.Generic;
using System.Text;

namespace ClientConsoleAppinterface
{
   public interface ClientServerCommunicationInterface
    {
        public Dictionary<string, Func<string>> GetEvents();
        public string MessageAnalytics(string massage);
    }
}
