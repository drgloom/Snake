using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
 
namespace Snake
{
    
    class Program
    {
        static NetServer server; // сервер
        static Thread listenThread; // потока для прослушивания
        
        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        static private void Server()
        {
            Console.WriteLine("проверка");
            try
            {
                server = new NetServer();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start(); //старт потока
            }
            catch (Exception ex)
            {
                server.Disconnect();
                Console.WriteLine(ex.Message);
            }
        }

        static private void Client()
        {
            Console.Write("Введите свое имя: ");
            userName = Console.ReadLine();
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток
 
                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
 
                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart((() => NetClient.ReceiveMessage(stream,client))));
                receiveThread.Start(); //старт потока
                Console.WriteLine("Добро пожаловать, {0}", userName);
                while (true)
                {
                    NetClient.PushDirection(stream);
                }
                //NetClient.SendMessage(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                NetClient.Disconnect(stream,client);
            }
        }

        static public void Game(NetworkStream stream)
        {
            while (true)
            {
                var snake = new SnakeObj();
                snake._direction = NetClient.GetDirection(stream);
                Console.WriteLine(snake._direction);  
            }
        }
        
        static void Main(string[] args)
        {
            int num;
            NetClient client2;
            Console.WriteLine("1 сервер 2 клиент");
            num = Convert.ToInt32(Console.ReadLine());
            switch (num)
            {
                case 1:
                    Server();
                    break;
                case 2:
                    Client();
                    break;
                default:
                    Console.WriteLine("проверка");
                    break;
            }
        }
    }
}