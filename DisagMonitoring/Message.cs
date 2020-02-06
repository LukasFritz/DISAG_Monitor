
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    public class Message
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

    }
}
