using System.Collections.Generic;

namespace DarkIslands.Harvesting
{
    public class HarvestController
    {

    }

    public class HarvestInfo
    {
        public HarvestInfo(bool canBeChopped, bool canBeMined, Dictionary<ResourceType, int> resourcesToHarvest)
        {
            CanBeChopped = canBeChopped;
            CanBeMined = canBeMined;
            ResourcesToHarvest = resourcesToHarvest;
        }

        public bool CanBeChopped { get; private set; }
        public bool CanBeMined { get; private set; }
        public Dictionary<ResourceType,int> ResourcesToHarvest { get; private set; }
        
    }
}