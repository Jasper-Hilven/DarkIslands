using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public partial class HarvestController
    {
        private HarvestControllerFactory fac;
        private IslandElement IslandElement;
        public IHarvestControllerTactic harvestTactic;

        public override void Init(IslandElement IslandElement, HarvestControllerFactory HarvestControllerFactory)
        {
            this.IslandElement = IslandElement;
            this.IslandElement.HarvestController = this;
            this.fac = HarvestControllerFactory;
            base.Init(IslandElement, HarvestControllerFactory);
        }

        public void SetHarvestSettings(IHarvestControllerTactic tactic, HarvestInfo info)
        {
            this.harvestTactic = tactic;
            this.IslandElement.HarvestInfo = info;
        }

        public InventoryAmount GetHarvested(float effort)
        {
            if (harvestTactic == null)
                return new InventoryAmount(new Dictionary<InventoryType, int>());
            return harvestTactic.GetHarvested(effort);
        }

        public void Harvest(float harvestEffort, IslandElement other)
        {
            if (harvestTactic == null)
                return;
            harvestTactic.Harvest(harvestEffort, other);
        }
    }
}