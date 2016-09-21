using System;
using System.Collections.Generic;

namespace DarkIslands
{
    
     /*   , //From Rock
        Gold, //From Gold rock
        RedMushroom, //From Red mushroom
        BrownMushroom, //From brown mushroom
        LavaStone,    //Loot from lava demon
        ThunderStone,   //Loot from thunder demon
        WaterStone,  //Loot from Water demon
        MindStone,   //Loot from mind demon
        PoisonStone, //Loot from poison demon
        PoisonBerry //Poison tree with mushroom (degrades to tree if picked)
        */

    public class ResourceType{
        public static ResourceType Wood = new ResourceType("Wood");
        public static ResourceType Stone = new ResourceType("Stone");
        public static ResourceType BrownMushroom = new ResourceType("BrownMushroom");
        public string Name { get; private set; }

        public ResourceType(string Name)
        {
            this.Name = Name;
        }

    }


   

    public class ResourceAmount
    {
        public ResourceAmount(Dictionary<ResourceType, int> amount)
        {
            Amount = amount;
        }
        public bool Empty { get
            {
                foreach (var item in Amount.Values)
                {
                    if (item > 0)
                        return false;
                }
                return true;
            } }
        public Dictionary<ResourceType,int>Amount { get; private set; }
    }
}