using System;
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

        public bool CanBeHarvested(HarvestResourceAction.HarvestAction action)
        {
            if(action == HarvestResourceAction.HarvestAction.Chop)
               return this.CanBeChopped;
            if (action == HarvestResourceAction.HarvestAction.Mine)
                return this.CanBeMined;
            if (action == HarvestResourceAction.HarvestAction.Smash)
                return this.CanBeHarvestAttacked;
            throw new NotImplementedException();
        }
        public bool CanHarvest(HarvestResourceAction.HarvestAction action)
        {
            if (action == HarvestResourceAction.HarvestAction.Chop)
                return this.CanChop;
            if (action == HarvestResourceAction.HarvestAction.Mine)
                return this.CanMine;
            if (action == HarvestResourceAction.HarvestAction.Smash)
                return this.CanHarvestAttack;
            throw new NotImplementedException();
        }
        public Dictionary<ResourceType,int> ResourcesToHarvest { get; private set; }
        
        public bool CanChop { get; private set; }
        public bool CanMine { get; private set; }
        public bool CanHarvestAttack { get; private set;}
    }
}