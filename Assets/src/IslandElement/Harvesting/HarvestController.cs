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
            this.fac = HarvestControllerFactory;
            base.Init(IslandElement, HarvestControllerFactory);
        }


        public ResourceAmount Harvest(float f)
        {
            if(harvestTactic ==null)
                return new ResourceAmount(new Dictionary<ResourceType, int>());
            throw new NotImplementedException();
        }
    }

    public interface IHarvestControllerTactic
    {
        ResourceAmount Harvest(float harvestEffort, IslandElement element);
    }

    public class TreeHarvestControllerTactic:IHarvestControllerTactic
    {
        public ResourceAmount Harvest(float harvestEffort, IslandElement element)
        {
            element.HarvestInfo.ResourcesToHarvest.ContainsKey(ResourceType.Wood);
            return null;
        }
    }
}