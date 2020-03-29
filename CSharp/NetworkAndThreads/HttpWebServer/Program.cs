using HttpWebServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpWebServer
{
    class Program
    {
        static public readonly string IP = "127.0.0.1";
        static public readonly int PORT = 8888;
        static public string SiteAddress { get => $"http://{IP}:{PORT}/"; }

        static void Main(string[] args)
        {
            ToDoCRUD.GetTicket(0); //Для первого запуска Entity
            var webServer = HttpServer.Get();
            webServer.SetWebServerAddress(IPAddress.Parse(IP), PORT);

            webServer.Start();

            Console.ReadLine();
        }
    }
}
