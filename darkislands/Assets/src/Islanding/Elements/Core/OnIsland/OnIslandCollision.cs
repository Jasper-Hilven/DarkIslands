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
            spaceIndex.Add(element);
        }
        public void RemoveElement(IslandElement element)
        {
            spaceIndex.Remove(element);
        }

        public void MoveElement(IslandElement element, Vector3 newPosition)
        {
            spaceIndex.Move(element,newPosition);
        }
        public bool CanMoveTowards(IslandElement mover, Vector3 oldPosition, Vector3 newPosition)
        {
            return spaceIndex.CanMoveWithoutCollision(mover, newPosition);
        }
        public Vector3 MoveElementWithoutColliding(IslandElement islandElement, Vector3 oldPosition, Vector3 newPosition)
        {
            if (!CanMoveTowards(islandElement, oldPosition, newPosition))
                newPosition = spaceIndex.GetElementPositionWithoutColliding(islandElement, oldPosition, newPosition);
            MoveElement(islandElement, newPosition);
            return newPosition;
        }

    }
}