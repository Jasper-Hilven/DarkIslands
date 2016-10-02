using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class InterIslandCollisionFactory
    {
        public TopDownCircleSpaceIndex TopdownIslandIndex
        {
            get; set;
        }

        private Dictionary<Island, Vector3> IslandToPosition = new Dictionary<Island, Vector3>();
        public void AddIsland(Island island)
        {
            if (TopdownIslandIndex == null)
                TopdownIslandIndex = new TopDownCircleSpaceIndex(100);
            IslandToPosition[island] = island.Position;
            TopdownIslandIndex.Add(island);
        }
       
        public void RemoveIsland(Island island)
        {
            if (TopdownIslandIndex == null)
                TopdownIslandIndex = new TopDownCircleSpaceIndex(100);
            IslandToPosition.Remove(island);
            TopdownIslandIndex.Remove(island);
        }

        public bool MoveDetectCollision(Island island, Vector3 newPosition)
        {
            if (TopdownIslandIndex == null)
                TopdownIslandIndex = new TopDownCircleSpaceIndex(100);
            var ret = TopdownIslandIndex.MoveDetectCollision(island, IslandToPosition[island], newPosition);
            IslandToPosition[island] = newPosition;
            return ret;
        }

        public List<Island> GetColliders(Island island)
        {
            if (TopdownIslandIndex == null)
                TopdownIslandIndex = new TopDownCircleSpaceIndex(100);
            return TopdownIslandIndex.GetColliders(island, island.Position).Select(c => (Island)c).ToList();
        }
    }
}