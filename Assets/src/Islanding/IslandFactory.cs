using UnityEngine;

namespace DarkIslands
{
    public partial class IslandFactory
    {
        public Island InitializeSimpleIsland(Vector3 position)
        {
            var island = this.Create();
            island.SizeController.SetInitialSize(20f);
            island.Position = position;
            return island;
        }
    }
}