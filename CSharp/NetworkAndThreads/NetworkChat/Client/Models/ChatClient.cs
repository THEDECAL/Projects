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
using System.Windows;

namespace Client.Models
{
    class ChatClient
    {
        public event Action<Message> ReceiveMessageEvent;
        static readonly int INPUT_BUFFER_SIZE = 256;
        IPEndPoint _ipEndPoint;
        Socket _serverSocket;
        CancellationTokenSource _receiverMessagesCancellationTokenSource = new CancellationTokenSource();
        public ChatClient(IPAddress serverIP, int serverPort)
        {
            _ipEndPoint = new IPEndPoint(serverIP, serverPort);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string userName)
        {
            _serverSocket.Connect(_ipEndPoint);
            ReceiverMessages();
            Thread.Sleep(1000);
            SendMessage(new Message() {Type = MsgType.USER_ADD, OwnerUserName = userName});
        }
        public void Disconnect(string userName)
        {
            _receiverMessagesCancellationTokenSource.Cancel();

            _serverSocket.Shutdown(SocketShutdown.Both);
            _serverSocket.Close();
        }
        public void SendMessage(Message msg)
        {
            var messageBytes = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(msg));
            _serverSocket.Send(messageBytes);
        }
        private async void ReceiverMessages()
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
                            _serverSocket.Receive(buffer);
                            messageBytes.AddRange(buffer);
                        }
                        while (_serverSocket.Available > 0);

                        var messageString = Encoding.Unicode.GetString(messageBytes.ToArray());
                        var splitMessages = messageString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var message in splitMessages)
                        {
                            var msg = JsonConvert.DeserializeObject<Message>(message);

                            if (msg != null) ReceiveMessageEvent(msg);
                        }
                    }
                }
                    catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
