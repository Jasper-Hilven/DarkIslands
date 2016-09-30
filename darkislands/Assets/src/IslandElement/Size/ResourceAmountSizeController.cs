using System;

namespace DarkIslands
{
    public class ResourceAmountSizeController:ISizeController
    {
        private InventoryType type;

        public ResourceAmountSizeController(InventoryType InventoryType)
        {
            this.type = InventoryType;
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