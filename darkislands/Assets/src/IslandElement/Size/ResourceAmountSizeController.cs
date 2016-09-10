using System;

namespace DarkIslands
{
    public class ResourceAmountSizeController:ISizeController
    {
        private ResourceType type;

        public ResourceAmountSizeController(ResourceType resourceType)
        {
            this.type = resourceType;
        }
        public float GetIslandElementSize(IslandElement islandElement)
        {
            var sizeRatio = 1f;
            var current = islandElement.HarvestInfo.ResourcesToHarvest[type];
            var max = islandElement.HarvestInfo.InitialResources[type];
            var ratio= ((float)current) / max;
            sizeRatio = UnityEngine.Mathf.Sqrt(ratio);
            return sizeRatio;

        }
    }
}