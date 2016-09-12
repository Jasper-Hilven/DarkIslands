using DarkIslands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DarkIslands
{
    public class DIInventoryDatabase
    {
        public static InventoryType Wood = new InventoryType("Wood", 1, 10, false,"This is wood");
        public static InventoryType Stone = new InventoryType("Stone", 2, 10, false, "This is stone");
        public static List<InventoryType> IdToType = new List<InventoryType>() { null, Wood, Stone };
        public static Item FromInventoryType(InventoryType iType)
        {
            if (!iconsLoaded)
                LoadIcons();
            return new Item(iType.Name, iType.UnityId, iType.Description, iType.Icon, null, iType.maxStack, ItemType.None, "sendmessagetext", new List<ItemAttribute>());
        }
        public static Item FromInventoryItem(InventoryItem item)
        {
            if (item == null)
                return null;
            if (!iconsLoaded)
                LoadIcons();
            var iType = item.InventoryType;
            var ret= new Item(iType.Name, iType.UnityId, iType.Description, iType.Icon, null, iType.maxStack, ItemType.None, "sendmessagetext", new List<ItemAttribute>());
            ret.itemValue = item.Amount;
            return ret;
        }
        private static bool iconsLoaded;
        public static void LoadIcons()
        {
            var icon = Resources.Load<UnityEngine.Sprite>("Icon_Wood");
            Wood.Icon = (Sprite)icon;
            Stone.Icon= (Sprite)Resources.Load<UnityEngine.Sprite>("Icon_Rock");
            iconsLoaded = true;
        }
        public InventoryItem ToInventoryItem(Item item)
        {
            if (item == null)
                return null;
            if (!iconsLoaded)
                LoadIcons();
            var type = IdToType[item.itemID];
            var amount = item.itemValue;
            return new InventoryItem(type, amount);
        }

       


        public Item getItemByID(int id)
        {
            if (!iconsLoaded)
                LoadIcons();
            var iType = IdToType[id];
            return FromInventoryType(iType);
        }
    }
}
