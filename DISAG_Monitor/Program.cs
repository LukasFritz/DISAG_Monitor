using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;

namespace DISAG_Monitor
{
    class Program
    {
        private const int listenPort = 30169;
        private static void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    //Console.WriteLine($"Received broadcast from {groupEP} :");
                    //Console.WriteLine($" {Encoding.UTF8 .GetString(bytes, 0, bytes.Length)}");
                    string telegram = Encoding.UTF8.GetString(bytes, 0, bytes.Length);

                    Message m = JsonConvert.DeserializeObject<Message>(telegram);
                    //object o = JsonConvert.DeserializeObject<Message>(m.ObjectsString); 

                    //m.

                    Console.WriteLine(m.getAll());

                    //if()

            }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }

        static void Main(string[] args)
        {
            StartListener();
        }
    }
}
