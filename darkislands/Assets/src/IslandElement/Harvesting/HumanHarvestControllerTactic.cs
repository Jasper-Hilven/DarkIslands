using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace DarkIslands
{
    public class HumanHarvestControllerTactic:IHarvestControllerTactic
    {
        public HumanHarvestControllerTactic(IslandElement element)
        {
            this.element = element;
        }

        private IslandElement element;
        public InventoryAmount GetHarvested(float harvestEffort)
        {
                return new InventoryAmount(new Dictionary<InventoryType, int>());
        }

        void IHarvestControllerTactic.Harvest(float harvestEffort, IslandElement harvested)
        {
            var resources = harvested.HarvestController.GetHarvested(harvestEffort);
            if(!resources.Empty())
                element.InventoryController.AddResources(resources);
        }
    }
}