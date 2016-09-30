using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public class HarvestInfo
    {
        public HarvestInfo(bool canBeChopped, bool canBeMined, Dictionary<InventoryType, int> resourcesToHarvest, Dictionary<InventoryType, int> initialResources, bool canChop, bool canMine, bool canBeHarvestAttacked, bool canHarvestAttack)
        {
            CanBeChopped = canBeChopped;
            CanBeMined = canBeMined;
            CanHarvestAttack = canHarvestAttack;
            ResourcesToHarvest = resourcesToHarvest ?? new Dictionary<InventoryType, int>();
            CanChop = canChop;
            CanMine = canMine;
            CanBeHarvestAttacked = canBeHarvestAttacked;
            this.InitialResources = initialResources ?? new Dictionary<InventoryType, int>();
        }


        public HarvestInfo ChangeResources(InventoryAmount changes, bool add = true)//TODO make simple clone
        {
            var rToHarvest = ResourcesToHarvest.ToDictionary(entry => entry.Key,entry => entry.Value);
            var initialResources= InitialResources.ToDictionary(entry => entry.Key,entry => entry.Value);
            foreach (var change in changes.Amount)
            {
                rToHarvest[change.Key] += add ? change.Value : -change.Value;
            }
            return new HarvestInfo(CanBeChopped, CanBeMined, rToHarvest, initialResources, CanChop, CanMine, CanBeHarvestAttacked,CanHarvestAttack);
        }

        public bool CanBeChopped { get; private set; }
        public bool CanBeMined { get; private set; }
        public bool CanBeHarvestAttacked { get; private set; }

        public bool CanBeHarvested(HarvestResourceAction.HarvestAction action)
        {
            if (action == HarvestResourceAction.HarvestAction.Chop)
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
        public Dictionary<InventoryType, int> ResourcesToHarvest { get; private set; }
        public Dictionary<InventoryType, int> InitialResources { get; private set; }

        public bool CanChop { get; private set; }
        public bool CanMine { get; private set; }
        public bool CanHarvestAttack { get; private set; }
    }
}