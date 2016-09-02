using System.Collections.Generic;

namespace DarkIslands
{
    public class Inventory
    {
        public List<ResourceAmount> resources { get; private set; }
        public Inventory(List<ResourceAmount> resources)
        {
            this.resources = resources;
        }

    }
}