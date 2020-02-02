using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISAG_Monitor
{
    class Message
    {
        public enum msgType { Command,Event };
        public enum msgVerb { Various, Shot, Series,Result };
        private string objectsString;

        public Message()
        {

        }

        #region Properties
        public msgType MessageType { get; set; }
        public msgVerb MessageVerb { get; set; }
        public bool Sequential { get; set; }
        public object Objects { get; set; }
        public string ObjectsString
        {
            get
            {
                return objectsString;
            }
            set
            {
                objectsString = value.ToString();
            }
        }
        public Guid UUID { get; set; }
        //public Array Objects { get; set; }
        #endregion

        public string getAll()
        {
            string result = $"Typ: {MessageType.ToString()}\nVerb: {MessageVerb.ToString()}\nSequenziell: {Sequential.ToString()}\nObjects As String: {Objects.ToString()}";
            return result;
        }

    }
}
