using System;

namespace DarkIslands
{
    public class TreeSizeController:ISizeController
    {
        public float GetIslandElementSize(IslandElement islandElement)
        {
            var sizeRatio = 1f;
            var current = islandElement.HarvestInfo.ResourcesToHarvest[ResourceType.Wood];
            var max = islandElement.HarvestInfo.InitialResources[ResourceType.Wood];
            sizeRatio = ((float)current) / max;
            return sizeRatio;

        }
    }
}