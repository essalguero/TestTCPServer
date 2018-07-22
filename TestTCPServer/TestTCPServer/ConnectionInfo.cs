using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Sockets;
using System.Net;

namespace TestTCPServer
{
    public class ConnectionInfo
    {
        public Socket connectionSocket { get; set; }


        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();

        public ConnectionInfo()
        {

        }

    }
}
