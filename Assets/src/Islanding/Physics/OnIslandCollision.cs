using UnityEngine;

namespace DarkIslands
{
    public partial class OnIslandCollision
    {
        private TopDownCircleSpaceIndex spaceIndex = new TopDownCircleSpaceIndex(8f);
        public override void Init(Island Island, OnIslandCollisionFactory OnIslandCollisionFactory)
        {
            Island.IslandCollision = this;
        }

        public void AddElement(IslandElement element)
        {
            this.spaceIndex.Add(element);
        }
        public void RemoveElement(IslandElement element)
        {
            this.spaceIndex.Remove(element);
        }

    }
}