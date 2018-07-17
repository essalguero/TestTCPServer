using System;

namespace TestTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            byte[] localAddress = { 127, 0, 0, 1 };
            int port = 33;
            System.Net.IPAddress address = new System.Net.IPAddress(localAddress);

            TCPServer server = new TCPServer(address, port);

        }
    }
}
