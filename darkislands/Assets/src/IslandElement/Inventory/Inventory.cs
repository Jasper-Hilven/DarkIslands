using System.Collections.Generic;

namespace DarkIslands
{
    public class InventoryIslandElement
    {
        public List<ResourceAmount> resources { get; private set; }
        public InventoryIslandElement(List<ResourceAmount> resources)
        {
            this.resources = resources;
        }

    }
}