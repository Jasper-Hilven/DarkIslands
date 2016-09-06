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


        public ResourceAmount GetHarvested(float effort)
        {
            if (harvestTactic == null)
                return new ResourceAmount(new Dictionary<ResourceType, int>());
            return harvestTactic.GetHarvested(effort);
        }

        public void Harvest(float harvestEffort, IslandElement other)
        {
            if (harvestTactic == null)
                return;
            harvestTactic.Harvest(harvestEffort, other);
        }
    }

    public interface IHarvestControllerTactic
    {
        void Harvest(float harvestEffort, IslandElement harvested);
        ResourceAmount GetHarvested(float harvestEffort);
    }
}