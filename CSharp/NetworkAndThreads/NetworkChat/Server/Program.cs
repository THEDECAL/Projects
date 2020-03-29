using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static readonly int LISTEN_PORT = 10240;
        static readonly IPAddress LISTEN_IP = IPAddress.Parse("127.0.0.1");//IPAddress.Any;
        static void Main()
        {
            ChatServer server = new ChatServer(LISTEN_IP, LISTEN_PORT, 10);
            server.Start();
        }
    }
}
