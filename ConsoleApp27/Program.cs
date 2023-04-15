using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    public class Program
    {   

        static void Main(string[] args)
        {
            string clientMessage = "";
            string serverMessage = "";
            
            TcpClient server = new TcpClient("127.0.0.1", 5000); /// server переменная для соединения с сервером на стороне клиента
            Console.WriteLine("Успешно подключились");

            NetworkStream stream = server.GetStream();

            StreamWriter sw = new StreamWriter(stream);
            StreamReader sr = new StreamReader(stream);

            while (true)
            {
                serverMessage = Console.ReadLine();
                sw.WriteLine(serverMessage);
                sw.Flush();
                clientMessage = sr.ReadToEnd();
                Console.WriteLine("server: " + clientMessage);
            }
        }
    }
}
