using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public class SimpleHarvestedControllerTactic:IHarvestControllerTactic
    {
        public SimpleHarvestedControllerTactic(IslandElement element, InventoryType InventoryType,bool dieOnEmpty=true)
        {
            this.InventoryType = InventoryType;
            this.element = element;
            this.dieOnEmpty = dieOnEmpty;
        }

        private IslandElement element;
        private InventoryType InventoryType;
        private bool dieOnEmpty;

        public InventoryAmount GetHarvested(float harvestEffort)
        {
            var ret= GetHarvestedResourcesCount(harvestEffort);
            if(element.HarvestInfo.ResourcesToHarvest[InventoryType] == 0)
                element.LifeController.Die();
            return ret;
        }

        private InventoryAmount GetHarvestedResourcesCount(float harvestEffort)
        {
            if (harvestEffort < 1f)
                return new InventoryAmount(new Dictionary<InventoryType, int>());

            if (element.HarvestInfo.ResourcesToHarvest[InventoryType] <= 0)
                return new InventoryAmount(new Dictionary<InventoryType, int>());
            var harvested = new Dictionary<InventoryType, int>();
            harvested[InventoryType] = 1;
            var InventoryAmount = new InventoryAmount(harvested);
            element.HarvestInfo = element.HarvestInfo.ChangeResources(InventoryAmount, false);
            return InventoryAmount;
        }

        void IHarvestControllerTactic.Harvest(float harvestEffort, IslandElement harvested)
        {
            return;
        }
    }
}