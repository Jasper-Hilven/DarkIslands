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
   
    public class InventoryType
    {
       
        public bool Usable { get; set; }
        public int maxStack { get; set; }
        public string Name { get; private set; }
        public int UnityId { get; set; }
        public string Description { get; private set; }
        public Sprite Icon { get; set; }

        public InventoryType(String name, int unityId,int stackamount,bool usable,String Description)
        {
            this.Description = Description;
            this.UnityId = unityId;
            this.Name = name;
            maxStack = stackamount;
            Usable = usable;
        }
    }
    public static class Resource
    {
        public static InventoryType ToInventory(this ResourceType rType)
        {
            if (rType == ResourceType.Wood)
                return DIInventoryDatabase.Wood;
            if (rType == ResourceType.Stone)
                return DIInventoryDatabase.Stone;
            throw new Exception("Unknown resourceType");
        }
    }
  

}
