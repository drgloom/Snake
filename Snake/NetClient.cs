using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
/*
namespace Snake {
    public class NetClient {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        private int score;
        private string userName;
        private TcpClient client;
        private NetServer server;
        private Board _board = new Board(10);
        public NetClient(TcpClient tcpClient, NetServer netServer) {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = netServer;
            netServer.AddConnection(this);
        }
        public void ProcessServer() {
            try {
                Stream = client.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;
                Console.WriteLine($"{userName} : Подключился к серверу");
                while (true) {
                    var temp = _board.PushBoard();
                    server.BroadcastMessage(temp, Id);
                    Thread.Sleep(1000);
                    /*
                    var key = GetMessage(Stream);
                    var snake = new SnakeObj();
                    snake._direction = GetDirection(Stream);
                    Console.WriteLine(snake._direction);
                    */
               // }

                /*
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
                */
                /*
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }
        static public void ProcessClient(NetworkStream stream, TcpClient client) {
            string message;
            Board board = new Board(10);
            Thread receiveThread = new Thread(new ThreadStart(() => PushDirection(stream)));
            receiveThread.Start(); //старт потока
            try {
                while (true) {
                    message = GetMessage(stream);
                    board.GetBoard(message);
                    board.DrawBoard();
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                Disconnect(stream, client);
            }
        }
        private static string GetMessage(NetworkStream stream) {
            try {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder message = new StringBuilder();
                int bytes = 0;
                do {
                    bytes = stream.Read(data, 0, data.Length);
                    message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (stream.DataAvailable);
                return message.ToString();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
        private string GetMessage() {
            try {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder message = new StringBuilder();
                int bytes = 0;
                do {
                    bytes = Stream.Read(data, 0, data.Length);
                    message.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (Stream.DataAvailable);
                return message.ToString();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        protected internal void Close() {
            if (Stream != null) Stream.Close();
            if (client != null) client.Close();
        }
        static public void SendMessage(NetworkStream stream, string message) {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
        // получение сообщений
        static public void ReceiveMessage(NetworkStream stream, TcpClient client) {
            while (true) {
                try {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);
                    string message = builder.ToString();
                    Console.WriteLine(message);//вывод сообщения
                }
                catch {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect(stream, client);
                }
            }
        }
        static public void Disconnect(NetworkStream stream, TcpClient client) {
            if (stream != null) stream.Close();//отключение потока
            if (client != null) client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }
        static public void PushDirection(NetworkStream stream) {
            Direction snake = Direction.UP;
            //SnakeObj snake = new SnakeObj();
            while (true) {
                var _cki = Console.ReadKey();
                switch (_cki.Key.ToString()) {
                    case "W":
                        snake = Direction.UP;
                        break;
                    case "S":
                        snake = Direction.DOWN;
                        break;
                    case "A":
                        snake = Direction.LEFT;
                        break;
                    case "D":
                        snake = Direction.RIGHT;
                        break;
                    default:
                        break;
                }
                var res = JsonSerializer.Serialize(snake);
                Console.WriteLine(res);
                SendMessage(stream, res);
            }
        }
        static public Direction GetDirection(NetworkStream stream) {
            try {
                var message = GetMessage(stream);
                var temp = JsonSerializer.Deserialize<Direction>(message);
                return temp;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
*/