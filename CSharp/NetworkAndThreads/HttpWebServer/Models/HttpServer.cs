using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace HttpWebServer.Models
{
    public class HttpServer
    {
        IPAddress _ip = IPAddress.Parse("127.0.0.1");
        int _port = 8888;
        static HttpServer _instance;
        readonly HttpListener _httpListener;
        readonly Site _site = Site.Get();

        public string URI { get => $"http://{_ip.ToString()}:{_port}/"; }

        HttpServer()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(URI);
        }

        public async void ListeningHttpRequestsAsync()
        {
            while (_httpListener.IsListening)
            {
                var httpContext = await _httpListener.GetContextAsync();
                var request = httpContext.Request;
                var response = httpContext.Response;

                Console.WriteLine($"Поступил запрос от: {request.RemoteEndPoint.ToString()}");

                NameValueCollection queryParams = new NameValueCollection();

                if (request.HttpMethod == "GET")
                {
                    queryParams = HttpUtility.ParseQueryString(request.Url.Query, Encoding.UTF8);
                }
                else if (request.HttpMethod == "POST")
                {
                    StreamReader reader = new StreamReader(request.InputStream);
                    string postQueryString = reader.ReadToEnd();
                    queryParams = HttpUtility.ParseQueryString(postQueryString, Encoding.UTF8);
                }

                _site.GetContent(request, response, queryParams);
                response.OutputStream.Close();
            }
        }
        /// <summary>
        /// Метод получения экземпляра класса
        /// </summary>
        /// <returns></returns>
        static public HttpServer Get() => _instance = _instance ?? new HttpServer();
        /// <summary>
        /// Метод установки адреса прослушивания
        /// </summary>
        /// <param name="ip">Принимает IP адрес</param>
        /// <param name="port">Принимает порт от 1 до 65535</param>
        public void SetWebServerAddress(IPAddress ip, int port)
        {
            if (port < 65536 && port > 1024)
            {
                _ip = ip; _port = port;
                _httpListener.Prefixes.Add(URI);
                Restart();
            }
            else throw new ArgumentOutOfRangeException();
        }
        public void Start()
        {
            if (!_httpListener.IsListening)
            {
                _httpListener.Start();
                ListeningHttpRequestsAsync();

                Console.WriteLine("Сервер запущен");
            }
        }
        public void Stop()
        {
            if (_httpListener.IsListening)
                _httpListener.Abort();
        }
        public void Restart()
        {
            Stop();
            Start();
        }
    }
}
