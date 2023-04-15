﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpServer = new TcpListener(IPAddress.Parse("127.0.0.1"),5000);
            tcpServer.Start();
            Console.WriteLine("Сервер запущен!!!");
            var client = tcpServer.AcceptSocket();
            Console.WriteLine($"Клиент подключился {client.RemoteEndPoint}");
            NetworkStream stream = new NetworkStream(client);
            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);
        }
    }
}