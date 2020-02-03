using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISAG_Monitor.Classes
{
    class MenuItem
    {
        public MenuItem()
        {
        }

        #region Properties
        public string MenuID { get; set; }
        public string MenuPointName { get; set; }
        public string MenuItemName { get; set; }
        public Guid UUID { get; set; }
    #endregion

}
}
