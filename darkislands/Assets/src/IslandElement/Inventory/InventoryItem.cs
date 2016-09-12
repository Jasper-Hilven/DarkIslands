using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkIslands
{
    public class InventoryItem
    {
        public int Amount;
        public int InventoryType;
    }
    public class InventoryType
    {
        public bool Usable { get; set; }
        public int Stackamount { get; set; }
        public InventoryType()
        {
            this.Usable = false;
            this.Stackamount = 1;
        }
    }
}
