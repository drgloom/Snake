﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Snake {
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server; // объект сервера

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream();
                // получаем имя пользователя
                //string message = GetMessage();
                //userName = message;

                //message = userName + " вошел в чат";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                //server.BroadcastMessage(message);
                //Console.WriteLine(message);
                // в бесконечном цикле получаем сообщения от клиента

                while (true)
                {
                    //Console.WriteLine(Program.tempBoard.ToString());

/*                        for (int i = 0; i < Program.tempBoard._size * Program.tempBoard._size; i++)
                        {
                            Console.Write(Program.tempBoard._line[i]);
                        }*/
                    
                        //Console.WriteLine(Program.tempBoard._line[0]);
                    server.BroadcastMessage(JsonSerializer.Serialize( Program.tempBoard ));
/*                    try
                    {
                        
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message);
                    }
                    catch
                    {
                        message = String.Format("{0}: покинул чат", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message);
                        break;
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        // чтение входящего сообщения и преобразование в строку
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}