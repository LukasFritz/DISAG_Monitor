using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    public class BroadcastListenerService
    {

        private int listenPort;
        private bool started;
        public event EventHandler<MessageEventArgs> OnTelegramArrived;
        #region Konstruktor
        public BroadcastListenerService()
        {
            this.ListenPort = 30169;
        }

        public BroadcastListenerService(int Port)
        {
            this.ListenPort = Port;
        }
        #endregion
        #region Properties
        private int ListenPort
        {
            get
            {
                return listenPort;
            }
            set
            {
                listenPort = value;
            }
        }
        #endregion
        #region Methods
        public void Start()
        {
            try
            {
                started = true;
                Thread t = new Thread(new ThreadStart(ListenerThread));
                t.Start();
                //Run Listener Service in while until started = false
            }
            catch
            {
                Stop();
                throw new Exception();
            }
            finally
            {
            }
        }

        public void Stop()
        {
            started = false;
        }

        private void ListenerThread()
        {
            
            while (started)
            {
                UdpClient listener = new UdpClient(listenPort);
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
                try
                {
#if DEBUG
                    Console.WriteLine("[DEBUG] Waiting for broadcast");
#endif
                    byte[] bytes = listener.Receive(ref groupEP);
                    string udpTelegram = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    Message m = JsonConvert.DeserializeObject<Message>(udpTelegram);
#if DEBUG
                    Console.WriteLine($"[DEBUG] {m.getAll()}");
#endif
                    //Eventhandler -> Telegram gekommen, übergebe m mit return
                    //Raise Event
                    OnTelegramArrived(this, new MessageEventArgs(m));

                }
                catch (SocketException e)
                {
                    Console.WriteLine($"[Exception] {e}");
                }
                finally
                {
                    listener.Close();
                }
            }
        }




        #endregion
    }

    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(Message m)
        {
            ArgsMessage = m;
        }
        public Message ArgsMessage { get; set; }
    }
}
