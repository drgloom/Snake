using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
/*
namespace Snake {
    public class NetServer {
        static TcpListener tcpListener; // сервер для прослушивания
        List<NetClient> clients = new List<NetClient>(); // все подключения
        private Board _board;
        protected internal void AddConnection(NetClient clientObject) {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id) {
            // получаем по id закрытое подключение
            NetClient client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        // прослушивание входящих подключений
        protected internal void Listen() {
            try {
                tcpListener = new TcpListener(IPAddress.Any, 8888);
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                while (true) {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    NetClient netClient = new NetClient(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(netClient.ProcessServer));
                    clientThread.Start();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Disconnect();
            }
        }
        // трансляция сообщения подключенным клиентам
        protected internal void BroadcastMessage(string message, string id) {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++) {
                // если id клиента не равно id отправляющего
                if (clients[i].Id != id) {
                    //передача данных
                    clients[i].Stream.Write(data, 0, data.Length);
                }
            }
        }
        // отключение всех клиентов
        protected internal void Disconnect() {
            tcpListener.Stop(); //остановка сервера
            for (int i = 0; i < clients.Count; i++) {
                clients[i].Close(); //отключение клиента
            }
            Environment.Exit(0); //завершение процесса
        }
    }
}
*/