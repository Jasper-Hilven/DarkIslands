using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public class TopDownCircleSpaceIndex
    {
        public Dictionary<IntVector2, List<ICircleElement>> BaseElements =
            new Dictionary<IntVector2, List<ICircleElement>>();
        public Dictionary<ICircleElement, IntVector2> CurrentPositions = new Dictionary<ICircleElement, IntVector2>();

        private float resolution;

        public TopDownCircleSpaceIndex(float cellSize)
        {
            this.resolution = 1/ cellSize;
        }

        public void Add(ICircleElement element)
        {
            AddElement(element,GetBasePosition(element.CollisionPosition));
        }

        public void Remove(ICircleElement element)
        {
            RemoveElement(element, GetBasePosition(element.CollisionPosition));
        }

        private IntVector2 GetBasePosition(Vector3 position)
        {
            return new IntVector2(Mathf.RoundToInt(position.x * resolution), Mathf.RoundToInt(position.z * resolution));
        }

        private List<ICircleElement> GetElements(IntVector2 chunk)
        {
            List<ICircleElement> ret;
            if (BaseElements.TryGetValue(chunk, out ret))
                return ret;
            ret = new List<ICircleElement>();
            BaseElements.Add(chunk,ret);
            return ret;
        }

        private void MoveElementBetweenChunks(ICircleElement element, IntVector2 oldPosition, IntVector2 newPosition)
        {
            RemoveElement(element, oldPosition);
            AddElement(element, newPosition);
        }

        private void AddElement(ICircleElement element, IntVector2 newPosition)
        {
            CurrentPositions[element] = newPosition;
            GetElements(new IntVector2(newPosition.x - 1, newPosition.y - 1)).Add(element);
            GetElements(new IntVector2(newPosition.x - 1, newPosition.y)).Add(element);
            GetElements(new IntVector2(newPosition.x - 1, newPosition.y + 1)).Add(element);
            GetElements(new IntVector2(newPosition.x, newPosition.y - 1)).Add(element);
            GetElements(new IntVector2(newPosition.x, newPosition.y)).Add(element);
            GetElements(new IntVector2(newPosition.x, newPosition.y + 1)).Add(element);
            GetElements(new IntVector2(newPosition.x + 1, newPosition.y - 1)).Add(element);
            GetElements(new IntVector2(newPosition.x + 1, newPosition.y)).Add(element);
            GetElements(new IntVector2(newPosition.x + 1, newPosition.y + 1)).Add(element);
        }

        private void RemoveElement(ICircleElement element, IntVector2 oldPosition)
        {
            CurrentPositions.Remove(element);
            GetElements(oldPosition).Remove(element);
            GetElements(new IntVector2(oldPosition.x - 1, oldPosition.y - 1)).Remove(element);
            GetElements(new IntVector2(oldPosition.x - 1, oldPosition.y)).Remove(element);
            GetElements(new IntVector2(oldPosition.x - 1, oldPosition.y + 1)).Remove(element);
            GetElements(new IntVector2(oldPosition.x, oldPosition.y - 1)).Remove(element);
            GetElements(new IntVector2(oldPosition.x, oldPosition.y)).Remove(element);
            GetElements(new IntVector2(oldPosition.x, oldPosition.y + 1)).Remove(element);
            GetElements(new IntVector2(oldPosition.x + 1, oldPosition.y - 1)).Remove(element);
            GetElements(new IntVector2(oldPosition.x + 1, oldPosition.y)).Remove(element);
            GetElements(new IntVector2(oldPosition.x + 1, oldPosition.y + 1)).Remove(element);
        }

        public void Move(ICircleElement element, Vector3 Position)
        {
            var oldBasePosition = CurrentPositions[element];
            var newBasePosition = GetBasePosition(Position);
            if (oldBasePosition == newBasePosition)
                return;
            MoveElementBetweenChunks(element,oldBasePosition,newBasePosition);


        }


        private bool collide(ICircleElement a, ICircleElement b,Vector3 bPosition)
        {
            if (a == b)
                return false;
            return (a.CollisionPosition - bPosition).sqrMagnitude <= (a.CircleElementProperties.Radius + b.CircleElementProperties.Radius)*(a.CircleElementProperties.Radius + b.CircleElementProperties.Radius);
        }
        public bool CanMoveWithoutCollision(ICircleElement element, Vector3 Position)
        {
            var basePos = this.GetBasePosition(Position);
            return !GetElements(basePos).Any(e => collide(e, element,Position));
        }

        public bool MoveDetectCollision(ICircleElement element, Vector3 previousPosition, Vector3 Position)
        {
            var oldBasePosition = GetBasePosition(previousPosition);
            var newBasePosition = GetBasePosition(Position);
            if (oldBasePosition != newBasePosition) { 
                MoveElementBetweenChunks(element, oldBasePosition, newBasePosition);
            }
            return GetElements(newBasePosition).Any(e => collide(e, element, Position));
        }
    }
}