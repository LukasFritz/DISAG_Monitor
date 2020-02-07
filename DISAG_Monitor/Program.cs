using System;
using System.Linq;
using System.Text;
using System.Data;
using DisagMonitoring;

namespace DISAG_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            BroadcastListenerService bListener = new BroadcastListenerService();
            bListener.OnTelegramArrived += bListener_OnTelegramArrived;
            bListener.Start();
        }

        private static void bListener_OnTelegramArrived(object sender, MessageEventArgs e)
        {
            Message m = new Message();
            m = e.ArgsMessage;
            if (m.MessageVerb == Message.msgVerb.Shot)
            {
                string name = "Unbekannter Schütze";
                try
                {
                    name = Message.GetPropertyValue(m, "Objects.Shooter.Firstname").ToString();
                }
                catch
                {
                }
                string range = Message.GetPropertyValue(m, "Objects.Range").ToString();
                string decValue = Message.GetPropertyValue(m, "Objects.DecValue").ToString();
                string str = $"{name} hat auf Stand {range} eine {decValue} geschossen.";

                Console.WriteLine(str);
            }
        }
    }
}
