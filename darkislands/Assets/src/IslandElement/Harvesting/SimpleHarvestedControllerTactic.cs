using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public class SimpleHarvestedControllerTactic:IHarvestControllerTactic
    {
        public SimpleHarvestedControllerTactic(IslandElement element, ResourceType resourceType,bool dieOnEmpty=true)
        {
            this.resourceType = resourceType;
            this.element = element;
            this.dieOnEmpty = dieOnEmpty;
        }

        private IslandElement element;
        private ResourceType resourceType;
        private bool dieOnEmpty;

        public ResourceAmount GetHarvested(float harvestEffort)
        {
            var ret= GetHarvestedResourcesCount(harvestEffort);
            if(element.HarvestInfo.ResourcesToHarvest[resourceType] == 0)
                element.LifeController.Die();
            return ret;
        }

        private ResourceAmount GetHarvestedResourcesCount(float harvestEffort)
        {
            if (harvestEffort < 1f)
                return new ResourceAmount(new Dictionary<ResourceType, int>());

            if (element.HarvestInfo.ResourcesToHarvest[resourceType] <= 0)
                return new ResourceAmount(new Dictionary<ResourceType, int>());
            var harvested = new Dictionary<ResourceType, int>();
            harvested[resourceType] = 1;
            var resourceAmount = new ResourceAmount(harvested);
            element.HarvestInfo = element.HarvestInfo.ChangeResources(resourceAmount, false);
            return resourceAmount;
        }

        void IHarvestControllerTactic.Harvest(float harvestEffort, IslandElement harvested)
        {
            return;
        }
    }
}