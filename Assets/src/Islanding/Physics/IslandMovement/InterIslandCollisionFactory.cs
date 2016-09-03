using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class InterIslandCollisionFactory
    {
        private TopDownCircleSpaceIndex topDownCircleSpaceIndex= new TopDownCircleSpaceIndex(100);
        private Dictionary<Island,Vector3> IslandToPosition= new Dictionary<Island, Vector3>();
        public void AddIsland(Island island)
        {
            IslandToPosition[island] = island.Position;
            topDownCircleSpaceIndex.Add(island);
        }

        public void RemoveIsland(Island island)
        {
            IslandToPosition.Remove(island);
            topDownCircleSpaceIndex.Remove(island);
        }

        public bool MoveDetectCollision(Island island, Vector3 newPosition)
        {
            var ret= topDownCircleSpaceIndex.MoveDetectCollision(island, IslandToPosition[island], newPosition);
            IslandToPosition[island] = newPosition;
            return ret;
        }
    }
}