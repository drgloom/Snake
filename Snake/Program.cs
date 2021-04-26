using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Snake {
    class Program
    {
        static public TempBoard tempBoard;
        static void Main(string[] args)
        {

        /*            int num;
                    //NetClient client2;
                    Console.WriteLine("1 сервер 2 клиент");
                    num = Convert.ToInt32(Console.ReadLine());
                    switch (num) {
                        case 1:
                            Server();
                            break;
                        case 2:
                            Client();
                            break;
                        default:
                            Console.WriteLine("проверка");
                            break;
                    }*/

        MenuStart();
        }
        static void MenuStart()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("1. Начать новую игру.");
                Console.WriteLine("2. Присоединиться.");
                Console.WriteLine("Esc. Выйти из программы.");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        MenuServerSize();
                        break;
                    case ConsoleKey.D2:
                        MenuConnect();
                        break;
                    case ConsoleKey.Escape:
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Введен неверный пункт меню. Нажмите любую клавишу для продолжения.");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
        static void MenuServerSize()
        {
            Console.Clear();
            Console.Write("Введите размер доски (10 по умолчанию): ");
            if (byte.TryParse(Console.ReadLine(), out byte size))
            {
                MenuServerPlayers(size);
            }
            else
            {
                MenuServerPlayers(size);
            }
            static void MenuServerPlayers(byte size)
            {
                Console.Clear();
                Console.Write("Введите количество игроков (1 по умолчанию): ");
                if (byte.TryParse(Console.ReadLine(), out byte count))
                {
                    tempBoard = new TempBoard(size);
                    Game game = new Game(size, count);
                    //Console.Clear();
                    Server();
                    game.Start();

                }
                else
                {
                    tempBoard = new TempBoard(size);
                    Game game = new Game(10, 0);
                    //Console.Clear();
                    Server();
                    game.Start();

                }
            }
        }
        static void MenuConnect()
        {
            Client();
        }

        static ServerObject server; // сервер
        static Thread listenThread; // потока для прослушивания

        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;

        static private void Server()
        {
            try
            {
                server = new ServerObject();
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
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                Console.WriteLine("Добро пожаловать, {0}", userName);
                SendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        static void SendMessage()
        {
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
        // получение сообщений
        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                                        byte[] data = new byte[64]; // буфер для получаемых данных
                                        StringBuilder builder = new StringBuilder();
                                        int bytes = 0;
                                        do
                                        {
                                            bytes = stream.Read(data, 0, data.Length);
                                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                                        }
                                        while (stream.DataAvailable);

                                        string message = builder.ToString();

                    //Console.WriteLine(message);//вывод сообщения
                    //stream.Read();
                    //Console.WriteLine("sssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
                    //var message = JsonSerializer.Serialize(Program.tempBoard);
                    tempBoard = JsonSerializer.Deserialize<TempBoard>(message);
                    //tempBoard.DrawBoard();
/*                        for (int j = 0; j < tempBoard._size * tempBoard._size; j++)
                        {
                            Console.WriteLine(tempBoard._line[j]);
                        }*/
                }
                catch
                {
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }
    }
}