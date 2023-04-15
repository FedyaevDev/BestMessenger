using System;
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
            string serverMessage = "";
            string clientMessage = "";
            try
            {
                TcpListener tcpServer = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
                tcpServer.Start();

                Console.WriteLine("Сервер запущен!!!");

                Socket client = tcpServer.AcceptSocket();

                Console.WriteLine($"Клиент подключился {client.RemoteEndPoint}");

                NetworkStream stream = new NetworkStream(client);

                StreamWriter sw = new StreamWriter(stream);
                StreamReader sr = new StreamReader(stream);

                while (true)
                {
                    if (client.Connected == true)
                    {
                        serverMessage = sr.ReadLine();
                        Console.WriteLine("клиент: " + serverMessage);
                        clientMessage = Console.ReadLine();
                        if (clientMessage == "exit")
                        {
                            stream.Close();
                            sw.Close();
                            sr.Close();
                            tcpServer.Stop();
                            client.Close();
                            Console.WriteLine("Клиент отключился");
                            break;
                        }
                        sw.WriteLine(clientMessage);
                        sw.Flush();
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
           

            Console.ReadLine();
        }
    }
}
