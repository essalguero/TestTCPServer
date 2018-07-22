using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Sockets;
using System.Net;
using System.Threading;


namespace TestTCPServer
{
    class TCPServer : TcpListener
    {
        private Socket listener;
        private IPEndPoint localEP;

        private ConnectionInfo info = new ConnectionInfo();

        private bool finishComunication = false;

        public static ManualResetEvent receptionEvent = new ManualResetEvent(false);

        public delegate void TcpServerEventDlg(object sender, TcpServerEventDlg e);



        private AsyncCallback ConnectionReady;
        private WaitCallback AcceptConnection;
        private AsyncCallback ReceivedDataReady;

        internal byte[] buffer;


        public TCPServer(IPAddress address, int port) : base(address, port)
        {
            Console.WriteLine("TCP Server created");

            localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);


            ConnectionReady = new AsyncCallback(ConnectionReady_Handler);
            //AcceptConnection = new WaitCallback(AcceptConnection_Handler());
            ReceivedDataReady = new AsyncCallback(ReceivedDataReady_Handler);

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

        void AcceptConnection_Handler(IAsyncResult ar)
        {


            //IAsyncResult ar = new IAsyncResult();
            //Socket listener = (Socket)ar.AsyncState;
            //Socket handler = listener.EndAccept(ar);
            Socket senderlistener = ar.AsyncState as Socket;
            Socket sender = listener.EndAccept(ar);

            ConnectionInfo info = new ConnectionInfo();

            info.connectionSocket = sender;
            

            //sender.BeginReceive(info.buffer, 0, info.BufferSize, SocketFlags.None, ReceivedDataReady, info);

            
        }

        /// <SUMMARY>
        /// Executes OnReceiveData method from the service provider.
        /// </SUMMARY>
        private void ReceivedDataReady_Handler(IAsyncResult ar)
        {

            ConnectionInfo info = ar.AsyncState as ConnectionInfo;

            listener.EndReceive(ar);
            //Im considering the following condition as a signal that the
            //remote host droped the connection.
            if (listener.Available != 0)
            {
                listener.Close();
            }
            else
            {
                listener.Close();
            }
        }

        private void ConnectionReady_Handler(IAsyncResult ar)
        {

        }

        public void Start()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEP);

                listener.Listen(20);

                //ConnectionInfo info = new ConnectionInfo();

                IAsyncResult result = listener.BeginAccept(new AsyncCallback(AcceptConnection), listener);

                while (!finishComunication)
                {
                    
                    //loop to avid the finalization of the server

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        


    }
}
