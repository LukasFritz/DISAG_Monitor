using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json;
using System.Data;

namespace DISAG_Monitor
{
    class Program
    {
        private DataSet shotsData = new DataSet("ShotsData");
        private const int listenPort = 30169;
        private static void StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);

            try
            {
                while (true)
                {
#if DEBUG
                    Console.WriteLine("[DEBUG] Waiting for broadcast");
#endif
                    byte[] bytes = listener.Receive(ref groupEP);

                    //Console.WriteLine($"Received broadcast from {groupEP} :");
                    //Console.WriteLine($" {Encoding.UTF8 .GetString(bytes, 0, bytes.Length)}");
                    string udpTelegram = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    Message m = JsonConvert.DeserializeObject<Message>(udpTelegram);
                    
#if DEBUG
                    Console.WriteLine($"[DEBUG] {m.getAll()}");
#endif
                    if (m.MessageVerb == Message.msgVerb.Shot)
                    {
                        string name = "Unbekannter Schütze";
                        try
                        {
                            name = GetPropertyValue(m, "Objects.Shooter.Firstname").ToString();
                        }
                        catch
                        {

                        }
                        string range = GetPropertyValue(m, "Objects.Range").ToString();
                        string decValue = GetPropertyValue(m, "Objects.DecValue").ToString();
                        string str = $"{name} hat auf Stand {range} eine {decValue} geschossen.";
                        Console.WriteLine(str);

                        Console.WriteLine(GetPropertyValue(m, "Objects.Range"));
                    }
                        
                        
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

        public static object GetPropertyValue(object src, string propName)
        {
            if (src == null) throw new ArgumentException("Value cannot be null.", "src");
            if (propName == null) throw new ArgumentException("Value cannot be null.", "propName");

            if (propName.Contains("."))//complex type nested
            {
                var temp = propName.Split(new char[] { '.' }, 2);
                return GetPropertyValue(GetPropertyValue(src, temp[0]), temp[1]);
            }
            else
            {
                var prop = src.GetType().GetProperty(propName);
                return prop != null ? prop.GetValue(src, null) : null;
            }
        }

        static void Main(string[] args)
        {
            StartListener();
        }
    }
}
