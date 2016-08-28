using UnityEngine;

namespace DarkIslands
{
    public partial class OnIslandCollision
    {
        private TopDownCircleSpaceIndex spaceIndex = new TopDownCircleSpaceIndex(4f);
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

        public void MoveElement(IslandElement element, Vector3 newPosition)
        {
            this.spaceIndex.Move(element,newPosition);
        }
        public bool CanMoveTowards(IslandElement mover, Vector3 oldPosition, Vector3 newPosition)
        {
            return spaceIndex.CanMoveWithoutCollision(mover, newPosition);
        }
    }
}