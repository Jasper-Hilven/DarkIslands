using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public partial class InventoryController
    {
        public IslandElement IslandElement { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public bool HasInventory
        {
            get
            {
                return Inventory != null;
            }
            set
            {
                if (value)
                    Inventory = Inventory ?? new List<InventoryItem>();
                else
                    Inventory = null;
            }
        }
        public override void Init(IslandElement IslandElement, InventoryControllerFactory InventoryControllerFactory)
        {
            base.Init(IslandElement, InventoryControllerFactory);
            this.IslandElement = IslandElement;
            this.IslandElement.InventoryController = this;
        }

        public void SetActiveToInventoryView()
        {

        }

        public void AddResource(ResourceAmount resHarvested)
        {
        }



    }
}