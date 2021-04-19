using System;
using System.Net.Sockets;
namespace Snake
{
    public class NetServer : Net
    {
        public NetServer() { }

        public NetServer(string ipAddress, int port) : base(ipAddress, port) { }

        public void Start()
        {
            try
            {
                _socket.Bind(_ip,_port);
                _socket.Listen(10);
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Socket был закрыт");
            }
            catch (SocketException)
            {
                throw new Exception("Произошла ошибка при попытке доступа к сокету");
            }
        }

        public Net NewClient()
        {
            NetClient net;
            try
            {
                var socket = _socket.Accept();
                net = new NetClient(socket);
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при установлении соединения с клиентом");
            }

            return net;
        }
    }
}