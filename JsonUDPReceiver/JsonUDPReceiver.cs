using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace JsonUDPReceiver
{
    public class JsonUDPReceiver
    {
        public void Start()
        {
            UdpClient client = new UdpClient(7765);

            while (true)
            {
                // TODO: Complete at home (no json here yet)

                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // values are overriden when it receives data.
                byte[] buffer = client.Receive(ref remoteEndPoint);
                string receivedMessage = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(receivedMessage);

                byte[] response = Encoding.UTF8.GetBytes($"\"{receivedMessage}\" received");
                client.Send(response, response.Length, remoteEndPoint);
            }
        }
    }
}
