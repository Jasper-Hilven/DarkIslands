using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkIslands
{
    partial class IslandElementFactory
    {
        public void DestroyIslandElementSafe(IslandElement IslandElement)
        {
            if (elements.Contains(IslandElement))
                DestroyIslandElement(IslandElement);
        }
    }
}
