using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DarkIslands
{
    public class InventoryItem
    {
        public int Amount;
        public InventoryType InventoryType;
        public InventoryItem(InventoryType type, int amount)
        {
            this.Amount = amount;
            this.InventoryType = type;
        }
        public InventoryItem TakeOffAmount(int amount)
        {
            if (amount <= 0 ||amount > Amount)
                throw new Exception();
            Amount -= amount;
            return new InventoryItem(InventoryType, amount);
        }
    }
}
