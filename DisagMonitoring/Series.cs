using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    class Series
    {
        public Series()
        {

        }
        public object Shooter { get; set; }
        public int ID { get; set; }
        public int FullValue { get; set; }
        public float DecimalValue { get; set; }
        public Guid UUID { get; set; }
    }
}
