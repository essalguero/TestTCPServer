using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Sockets;
using System.Net;

namespace TestTCPServer
{
    class TCPServer : TcpListener
    {
        private Socket listener;
        private IPEndPoint localEP;

        public TCPServer(IPAddress address, int port) : base(address, port)
        {
            Console.WriteLine("TCP Server created");

            localEP = new IPEndPoint(address, port);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        void acceptConnection(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
        }

        void startListening()
        {
            listener = new Socket(localEP.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEP);

                listener.Listen(20);

                while (true)
                {
                    listener.BeginAccept(new AsyncCallback(acceptConnection), listener);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        


    }
}
