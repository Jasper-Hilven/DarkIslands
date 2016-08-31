using System;

namespace DarkIslands
{
    public partial class InventoryController
    {
        public IslandElement IslandElement { get; set; }
        public override void Init(IslandElement IslandElement, InventoryControllerFactory InventoryControllerFactory)
        {
            base.Init(IslandElement, InventoryControllerFactory);
            this.IslandElement = IslandElement;
            this.IslandElement.InventoryController = this;
        }


        public void AddResource(ResourceAmount resHarvested)
        {
            Console.Out.WriteLine("Resources added");
        }
    }
}