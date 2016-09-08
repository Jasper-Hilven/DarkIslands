using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public enum ResourceType
    {
        Wood, //From Tree
        Stone, //From Rock
        Gold, //From Gold rock
        RedMushroom, //From Red mushroom
        BrownMushroom, //From brown mushroom
        LavaStone,    //Loot from lava demon
        ThunderStone,   //Loot from thunder demon
        WaterStone,  //Loot from Water demon
        MindStone,   //Loot from mind demon
        PoisonStone, //Loot from poison demon
        PoisonBerry //Poison tree with mushroom (degrades to tree if picked)
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