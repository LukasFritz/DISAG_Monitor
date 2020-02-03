using DISAG_Monitor.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    class Message
    {
        public enum msgType { Command,Event };
        public enum msgVerb { Various, Shot, Series,Result };
        //private string objectsString;
        private object objects;

        public Message()
        {

        }

        #region Properties
        public msgType MessageType { get; set; }
        public msgVerb MessageVerb { get; set; }
        public bool Sequential { get; set; }
        public object Objects
        {
            get
            {
                return objects;
            }
            set
            {
                switch (this.MessageVerb)
                {
                    case Message.msgVerb.Various:
                        objects = null;
                        break;
                    case Message.msgVerb.Shot:
                        Shot shot = JsonConvert.DeserializeObject<Shot>(value.ToString().Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(@"\", "").Replace("[", "").Replace("]", ""));
                        objects = shot;
                        break;
                    case Message.msgVerb.Series:
                        Series series = JsonConvert.DeserializeObject<Series>(value.ToString().Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(@"\", "").Replace("[", "").Replace("]", ""));
                        objects = series;
                        break;
                    case Message.msgVerb.Result:
                        Result result = JsonConvert.DeserializeObject<Result>(value.ToString().Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(@"\", "").Replace("[", "").Replace("]", ""));
                        objects = result;
                        break;
                    default:
                        break;
                }
            }
        }
        
        public Guid UUID { get; set; }
        #endregion

        public string getAll()
        {
            string result = $"Typ: {MessageType.ToString()}\nVerb: {MessageVerb.ToString()}\nSequenziell: {Sequential.ToString()}\nObjects As String: {Objects.ToString()}";
            return result;
        }

    }
}
