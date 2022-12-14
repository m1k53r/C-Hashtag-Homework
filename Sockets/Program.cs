using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sockets
{
    class Program
    {
        private static List<Socket> clients = new List<Socket>();
        private static TcpListener listener;
        private static Dictionary<string, string> names = new Dictionary<string, string>();

        //TODO: make it a chat
        //TODO: clients should be able to connect from all over the world (change IP in SocketsClient, it's the only thing to change there)
        //TODO: whenever client disconnects server crashes.

        static void Main(string[] args)
        {
            listener = new TcpListener(IPAddress.Any, 7865);
            listener.Start();

            Console.WriteLine("Waiting for connection...");
            BeginAccepting();

            Console.ReadKey();
        }

        private static void BeginAccepting()
        {
            listener.BeginAcceptSocket(connectionCallback, new object());
        }

        private static void sendToAllClients(string msg)
        {
            byte[] newMsg = Encoding.ASCII.GetBytes(msg);
            clients.ForEach(c => c.Send(newMsg));
        }

        private static void sendToAllClientsExceptCurrent(string msg, Socket client)
        {
            byte[] newMsg = Encoding.ASCII.GetBytes(msg);
            clients.Where(c => c != client).ToList().ForEach(c => c.Send(newMsg));
        }
        private static void sendToCurrentClient(string msg, Socket client)
        {
            byte[] newMsg = Encoding.ASCII.GetBytes(msg);
            client.Send(newMsg);
        }

        private static string receive(Socket client)
        {
            var bytes = new byte[1024];
            var i = client.Receive(bytes);
            var str = Encoding.UTF8.GetString(bytes, 0, i);
            return str;
        }

        private static void connectionCallback(IAsyncResult ar)
        {
            string msg = "";
            var client = listener.EndAcceptSocket(ar);
            clients.Add(client);
            sendToAllClientsExceptCurrent($"New client has connected from ip: {client.RemoteEndPoint}", client);
            Console.WriteLine($"Connected {client.RemoteEndPoint}");

            new Thread(() =>
            {
                if (client.Connected)
                {
                    names.Add(client.RemoteEndPoint.ToString(), receive(client));
                    sendToCurrentClient("-----------------------------", client);
                    sendToAllClients($"{names[client.RemoteEndPoint.ToString()]} has joined the chat");
                }
                while (client.Connected)
                {
                    msg = $"{names[client.RemoteEndPoint.ToString()]}: " + receive(client);
                    sendToAllClients(msg);
                    Console.WriteLine(msg);
                }
                Console.WriteLine($"client {client.AddressFamily} disconnected");
            })
            {

            }.Start();

            BeginAccepting();
        }
    }
}
