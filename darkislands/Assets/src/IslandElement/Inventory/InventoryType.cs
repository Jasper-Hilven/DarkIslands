using System;
using UnityEngine;

namespace DarkIslands
{
    public class InventoryType
    {
       
        public bool Usable { get; set; }
        public int maxStack { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public InventoryType(String name, int stackamount,bool usable,String Description,Func<GameObject> viewMethod)
        {
            this.Description = Description;
            this.Name = name;
            maxStack = stackamount;
            Usable = usable;
        }

        internal GameObject GetViewObject()
        {
            throw new NotImplementedException();
        }
    }
    public class InventoryDatabase
    {
        public InventoryType Wood;
        public InventoryType Stone ;
        public InventoryType BrownMushroom;
        public InventoryType Grass;
        public InventoryDatabase(UnityViewFactory viewFac)
        {
            Wood =  new InventoryType("Wood", 10, false, "This is wood", () => viewFac.GetWoodVisualization());
            Stone = new InventoryType("Stone", 10, false, "This is stone",()=> viewFac.GetStoneVisualization());
            BrownMushroom = new InventoryType("BrownMushroom", 10, false, "This is a brown mushroom", () => viewFac.GetBrownMushroomVisualization(0));
            Grass = new InventoryType("Grass", 10, false, "This is a bunch o grass", () => viewFac.GetGrassVisualization(0));
        }
    }
}