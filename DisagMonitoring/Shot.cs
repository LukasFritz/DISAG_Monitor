using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisagMonitoring
{
    public class Shot
    {
        public enum tlColors { off, red, green};
        public enum src { OpticScore, RedDot}
        public enum discType { LG, LGA, LP, LPA, KK, KKA, KYFFH, ZS, ZSA, ZSTRD, LPS, LPI }
        

        public Shot()
        {

        }

        #region properties
        /// <summary>
        /// Zeitstempel des Schusses
        /// </summary>
        public DateTime ShotDateTime { get; set; }
        /// <summary>
        /// Zustand der Ampel beim Schuss
        /// </summary>
        public tlColors TLStatus { get; set; }
        /// <summary>
        /// Zeit in ms seit letzter Ampelschaltung
        /// </summary>
        public int LastTLChange { get; set; }
        /// <summary>
        /// Schussherkunft OpticScore,RedDot
        /// </summary>
        public src Source { get; set; }
        /// <summary>
        /// Standnummer
        /// </summary>
        public int Range { get; set; }
        /// <summary>
        /// Schütze siehe Klasse Shooter
        /// </summary>
        public Shooter Shooter { get; set; }
        /// <summary>
        /// Scheibenart siehe Klasse DiscType
        /// </summary>
        public discType DiscType { get; set; }
        /// <summary>
        /// X-Position des Schusses -9000 bis 9000
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y-Positin des Schusses -9000 bis 9000
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Teiler
        /// </summary>
        public float Distance { get; set; }
        public int Count { get; set; }
        public int FullValue { get; set; }
        public float DecValue { get; set; }
        public int Run { get; set; }
        public bool IsValid { get; set; }
        public bool IsWarmup { get; set; }
        public bool IsHot { get; set; }
        public bool IsDummy { get; set; }
        public bool IsInnerten { get; set; }
        public bool IsShootoff { get; set; }
        public MenuItem MenuItem { get; set; }
        public string Remark { get; set; }
        public Guid UUID { get; set; }


        #endregion

    }
}
