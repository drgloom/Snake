using System;
using System.Net.Sockets;
using System.Text;

namespace Snake
{
    public class NetClient
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream {get; private set;}
        private int score;
        private string userName;
        private TcpClient client;
        private NetServer server;
        
        public NetClient(TcpClient tcpClient, NetServer netServer)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = netServer;
            netServer.AddConnection(this);
        }
 
        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;
 
                message = userName + " вошел в игру";
                // посылаем сообщение о входе в игру всем подключенным пользователям
                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        message = String.Format("{0}: покинул чат", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        } //TODO НАПИСАТЬ ПРОЦЕСС РАБОТЫ КЛИЕНТА
        
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder message = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                message.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);
 
            return message.ToString();
        }
        
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}