using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public enum ResourceType
    {
        Wood,
        Stone,
        Gold,
        LavaStone,
        ThunderStone,
        Ice,
        MindStone,
        PoisonBerry
    }

    public class ResourceAmount
    {
        public ResourceAmount(Dictionary<ResourceType, int> amount)
        {
            Amount = amount;
        }

        public Dictionary<ResourceType,int>Amount { get; private set; }
    }
}