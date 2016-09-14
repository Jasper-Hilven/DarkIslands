using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public class TopDownCircleSpaceIndex
    {
        private readonly SpaceIndex decoSpaceIndex;


        public TopDownCircleSpaceIndex(float cellSize)
        {
            decoSpaceIndex = new SpaceIndex(cellSize);
        }


        private bool collide(ICircleElement a, ICircleElement b, Vector3 bPosition)
        {
            if (a == b)
                return false;
            if (a.CircleElementProperties == null)
                return false;
            if (b.CircleElementProperties == null)
                return false;
            return (a.IndexPosition - bPosition).sqrMagnitude < (a.CircleElementProperties.Radius + b.CircleElementProperties.Radius) * (a.CircleElementProperties.Radius + b.CircleElementProperties.Radius);
        }
        public bool CanMoveWithoutCollision(ICircleElement element, Vector3 Position)
        {
            return !decoSpaceIndex.GetElements(Position).Any(e => collide((ICircleElement)e, element, Position));
        }

        public bool MoveDetectCollision(ICircleElement element, Vector3 previousPosition, Vector3 Position)
        {
            var oldBasePosition = decoSpaceIndex.GetBasePosition(previousPosition);
            var newBasePosition = decoSpaceIndex.GetBasePosition(Position);
            if (oldBasePosition != newBasePosition)
            {
                decoSpaceIndex.MoveElementBetweenChunks(element, oldBasePosition, newBasePosition);
            }
            return decoSpaceIndex.GetElements(Position).Any(e => collide((ICircleElement)e, element, Position));
        }

        public List<ICircleElement> GetColliders(ICircleElement element, Vector3 Position)
        {
            return decoSpaceIndex.GetElements(Position).Where(e => collide((ICircleElement)e, element, Position)).Select(e => (ICircleElement)e).ToList();
        }
        public Vector3 GetElementPositionWithoutColliding(ICircleElement element, Vector3 oldPosition, Vector3 newPosition)
        {
            var allButMe = decoSpaceIndex.GetElements(newPosition).Where(e => e != element).ToList();
            newPosition = allButMe.Aggregate(newPosition, (current, circleElement) => PushPositionAway(current, element.CircleElementProperties.Radius, (ICircleElement)circleElement));
            return !CanMoveWithoutCollision(element, newPosition) ? oldPosition : newPosition; //If still collision after correction => Don't move
        }

        public Vector3 PushPositionAway(Vector3 Position, float radius, ICircleElement other)
        {
            var otherRad = other.CircleElementProperties.Radius;
            var distance = Position - other.IndexPosition;
            var sqrMagnitude = distance.sqrMagnitude;
            var totalRadius = otherRad + radius;
            if (sqrMagnitude > totalRadius * totalRadius)
                return Position;
            return other.IndexPosition + (totalRadius + 0.01f) * distance.normalized;
        }
        public void Add(IIndexedElement element)
        {
            decoSpaceIndex.Add(element);
        }

        public void Remove(IIndexedElement element)
        {
            decoSpaceIndex.Remove(element);
        }
        public void Move(ICircleElement element, Vector3 Position)
        {
            decoSpaceIndex.Move(element, Position);
        }
    }
}