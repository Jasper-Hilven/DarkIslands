using System;

namespace DarkIslands
{
    public class InventoryType
    {
       
        public bool Usable { get; set; }
        public int maxStack { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public static InventoryType Wood = new InventoryType("Wood", 10, false, "This is wood");
        public static InventoryType Stone = new InventoryType("Stone", 10, false, "This is stone");
        public static InventoryType BrownMushroom = new InventoryType("BrownMushroom", 10, false, "This is a brown mushroom");
        public static InventoryType Grass = new InventoryType("Grass", 10, false, "This is a brown mushroom");


        public InventoryType(String name, int stackamount,bool usable,String Description)
        {
            this.Description = Description;
            this.Name = name;
            maxStack = stackamount;
            Usable = usable;
        }
    }
}