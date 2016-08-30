using System.Collections.Generic;

namespace DarkIslands
{
    public class HarvestInfo
    {
        public HarvestInfo(bool canBeChopped, bool canBeMined, Dictionary<ResourceType, int> resourcesToHarvest, bool canChop, bool canMine, bool canBeHarvestAttacked)
        {
            CanBeChopped = canBeChopped;
            CanBeMined = canBeMined;
            ResourcesToHarvest = resourcesToHarvest;
            CanChop = canChop;
            CanMine = canMine;
            CanBeHarvestAttacked = canBeHarvestAttacked;
        }

        public bool CanBeChopped { get; private set; }
        public bool CanBeMined { get; private set; }
        public bool CanBeHarvestAttacked { get; private set;}
        public Dictionary<ResourceType,int> ResourcesToHarvest { get; private set; }
        
        public bool CanChop { get; private set; }
        public bool CanMine { get; private set; }
        public bool CanHarvestAttack { get; private set;}
    }
}