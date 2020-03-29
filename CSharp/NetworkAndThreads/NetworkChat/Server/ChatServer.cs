using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MessageLibrary;

namespace Server
{
    class ChatServer
    {
        static readonly int INPUT_BUFFER_SIZE = 256;
        IPEndPoint _ipEndPoint;
        Socket _listenSocket;
        int _queueConnectionSize;
        //Mutex _clientsMutex = new Mutex();
        Dictionary<Socket, string> _clients = new Dictionary<Socket, string>();
        CancellationTokenSource _receiverMessagesCancellationTokenSource = new CancellationTokenSource();
        public ChatServer(IPAddress listenIP, int listenPort, int queueConnectionSize)
        {
            _queueConnectionSize = queueConnectionSize;
            _ipEndPoint = new IPEndPoint(listenIP, listenPort);
            _listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        ~ChatServer()
        {
            Stop();
        }
        public void Start()
        {
            try
            {
                _listenSocket.Bind(_ipEndPoint);
                _listenSocket.Listen(_queueConnectionSize);

                Console.WriteLine("Server is started...");
                Console.WriteLine();

                while (true)
                {
                    Socket clientConn = _listenSocket.Accept();
                    lock (_clients)
                    {
                        _clients.Add(clientConn, "");
                    }

                    Console.WriteLine($"Client {clientConn.RemoteEndPoint} connected.");

                    ReceiverMessages(clientConn);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Stop(); }

            Console.ReadKey();
        }
        public void Stop()
        {
            _receiverMessagesCancellationTokenSource.Cancel();

            _listenSocket.Shutdown(SocketShutdown.Both);
            _listenSocket.Close();

            _clients.Clear();

            Console.WriteLine("Server is stoped...");
        }
        public void Restart()
        {
            Stop();
            Start();

            Console.WriteLine("Server is restarted...");
        }
        private async void ReceiverMessages(Socket socket)
        {
            var cancellationToken = _receiverMessagesCancellationTokenSource.Token;

            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            return;

                        List<byte> messageBytes = new List<byte>();
                        byte[] buffer = new byte[INPUT_BUFFER_SIZE];
                        do
                        {
                            buffer = new byte[INPUT_BUFFER_SIZE];
                            socket.Receive(buffer);
                            messageBytes.AddRange(buffer);
                        }
                        while (socket.Available > 0);

                        var messageString = Encoding.Unicode.GetString(messageBytes.ToArray());
                        var splitMessages = messageString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var message in splitMessages)
                        {
                            var msg = JsonConvert.DeserializeObject<Message>(message);

                            if (msg != null)
                            {
                                if (msg.Type == MsgType.USER_ADD)
                                {
                                    //Добавление списка текущих пользователей подключенному пользователю
                                    if (_clients.Count > 0)
                                    {
                                        foreach (var userName in _clients.Values)
                                        {
                                            if (userName != "")
                                            {
                                                var addMessage = JsonConvert.SerializeObject(new Message() { Type = MsgType.USER_ADD, OwnerUserName = userName });
                                                socket.Send(Encoding.Unicode.GetBytes(addMessage));
                                            }
                                        }
                                    }

                                    //Добавление имени пользователя в словарь
                                    lock (_clients) _clients[socket] = msg.OwnerUserName;
                                    Console.WriteLine($"User {msg.OwnerUserName} ({socket.RemoteEndPoint}) enter.");
                                }
                                //else if (msg.Type == MsgType.PRIVATE_MSG)
                                //{
                                //}
                                //else
                                //{

                                //}
                            }
                        }

                        foreach (var client in _clients.Keys)
                            client.Send(messageBytes.ToArray());
                    }
                }
                catch (SocketException)
                {
                    var userName = _clients[socket];
                    Console.WriteLine($"Client {socket.RemoteEndPoint} disconnected.");
                    Console.WriteLine($"User {_clients[socket]} ({socket.RemoteEndPoint}) exit.");
                    lock (_clients) _clients.Remove(socket);

                    if (userName != "")
                    {
                        var message = JsonConvert.SerializeObject(new Message() { Type = MsgType.USER_DEL, OwnerUserName = userName });

                        foreach (var client in _clients.Keys)
                            client.Send(Encoding.Unicode.GetBytes(message));
                    }
                }
            });
        }
    }
}
