using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketsClient
{
    class Program
    {
        static Socket s;
        static byte[] bytes = new byte[1024];

        static void Main(string[] args)
        {
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //TODO: locally can be tested on 127..., but to access from different placed needs to be replaced
                //TODO: replace to server's IP to access the server
                s.Connect("127.0.0.1", 7865);

                s.BeginReceive(bytes, 0, 1024, SocketFlags.None, DataReceived, null);

                Console.WriteLine("whats your name?");
                var name = Console.ReadLine();

                s.Send(Encoding.UTF8.GetBytes(name));

                while (true)
                {
                    var ln = Console.ReadLine();
                    if (ln.ToLower() == "x")
                    {
                        break;
                    }
                    s.Send(Encoding.UTF8.GetBytes(ln));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("Press any key to exit");
            Console.WriteLine("\t\twhich one is any?!");
            Console.ReadKey();
        }


        static void DataReceived(IAsyncResult ar)
        {
            var i = s.EndReceive(ar);
            Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, i));
            s.BeginReceive(bytes, 0, 1024, SocketFlags.None, DataReceived, null);
        }
    }
}
