﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client");

            var client = new Client();
            client.ConnectSockets();

            Thread thread = new Thread(() =>
            {
                while (client.SocketWrite.Connected)
                {
                    client.SendMessageToServer(Console.ReadLine());
                }
            });
            thread.IsBackground = false;
            thread.Start();

            client.GetMessages();
        }
    }
}
