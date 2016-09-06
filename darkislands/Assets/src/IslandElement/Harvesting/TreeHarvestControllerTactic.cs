using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public class TreeHarvestControllerTactic:IHarvestControllerTactic
    {
        public TreeHarvestControllerTactic(IslandElement element)
        {
            this.element = element;
        }

        private IslandElement element;
        public ResourceAmount GetHarvested(float harvestEffort)
        {
            if(harvestEffort < 1f)
                return new ResourceAmount(new Dictionary<ResourceType, int>());

            if (element.HarvestInfo.ResourcesToHarvest[ResourceType.Wood] <= 0)
                return new ResourceAmount(new Dictionary<ResourceType, int>());
            var chopAWood = new Dictionary<ResourceType, int>();
            chopAWood[ResourceType.Wood] = 1;
            var resourceAmount = new ResourceAmount(chopAWood);
            element.HarvestInfo = element.HarvestInfo.ChangeResources(resourceAmount, false);
            return resourceAmount;
        }

        void IHarvestControllerTactic.Harvest(float harvestEffort, IslandElement harvested)
        {
            return;
        }
    }
}