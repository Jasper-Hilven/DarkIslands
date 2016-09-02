using System;

namespace DarkIslands
{
    public class TreeSizeController:ISizeController
    {
        public float GetIslandElementSize(IslandElement islandElement)
        {
            var sizeRatio = 1f;
            try
            {
                sizeRatio = ((float)islandElement.HarvestInfo.ResourcesToHarvest[ResourceType.Wood]) /
                                 (islandElement.HarvestInfo.InitialResources[ResourceType.Wood]);
            }
            catch (Exception e)
            {
            }
            return sizeRatio;

        }
    }
}