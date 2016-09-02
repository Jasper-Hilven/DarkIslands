using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public class HumanHarvestControllerTactic:IHarvestControllerTactic
    {
        public HumanHarvestControllerTactic(IslandElement element)
        {
            this.element = element;
        }

        private IslandElement element;
        public ResourceAmount GetHarvested(float harvestEffort)
        {
                return new ResourceAmount(new Dictionary<ResourceType, int>());
        }

        void IHarvestControllerTactic.Harvest(float harvestEffort, IslandElement harvested)
        {
            var resources = harvested.HarvestController.GetHarvested(harvestEffort);
            element.InventoryController.AddResource(resources);
        }
    }
}