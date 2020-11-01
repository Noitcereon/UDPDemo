using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using ModelLib;

namespace JsonUDPSender
{
    public class JsonUDPSender
    {
        public void Start()
        {
            UdpClient client = new UdpClient();

            Car car = new Car("Citroën", "Silver", "BG624K");
            string message = JsonSerializer.Serialize(car);
            byte[] bytesToSend = Encoding.UTF8.GetBytes(message);

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, 7765);
            client.Send(bytesToSend, bytesToSend.Length, remoteEndPoint);
            Console.WriteLine(message + " ---  was sent");
        }
    }
}
