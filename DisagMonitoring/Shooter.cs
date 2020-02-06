using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    public class Shooter
    {
        public Shooter()
        {
        }

        #region Properties
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Birthyear { get; set; }
        public string InternalID { get; set; }
        public string Identification { get; set; }
        public Team Team { get; set; }
        public Club Club { get; set; }
        public Guid UUID { get; set; }


    }

    #endregion


}



