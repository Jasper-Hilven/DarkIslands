using UnityEngine;

namespace DarkIslands
{
    public partial class IslandFactory
    {
        public Island InitializeSimpleIsland(Vector3 position)
        {
            var island = this.Create();
            island.Size = 20f;
            island.Position = position;
            island.CircleElementProperties = new CircleElementProperties(20, 20);
            return island;
        }
    }
}