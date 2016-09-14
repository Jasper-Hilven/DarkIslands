using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public class SpaceIndex
    {
        public Dictionary<IntVector2, List<IIndexedElement>> BaseElements =
            new Dictionary<IntVector2, List<IIndexedElement>>();
        public Dictionary<IIndexedElement, IntVector2> CurrentPositions = new Dictionary<IIndexedElement, IntVector2>();

        private float resolution;

        public SpaceIndex(float cellSize)
        {
            resolution = 1 / cellSize;
        }

        public void Add(IIndexedElement element)
        {
            AddElement(element, GetBasePosition(element.IndexPosition));
        }

        public void Remove(IIndexedElement element)
        {
            RemoveElement(element, GetBasePosition(element.IndexPosition));
        }

        public IntVector2 GetBasePosition(Vector3 position)
        {
            return new IntVector2(Mathf.RoundToInt(position.x * resolution), Mathf.RoundToInt(position.z * resolution));
        }

        public List<IIndexedElement> GetElements(Vector3 Position)
        {
            var basePosition = GetBasePosition(Position);
            return GetElements(basePosition);
        }

        private List<IIndexedElement> GetElements(IntVector2 chunk)
        {
            List<IIndexedElement> ret;
            if (BaseElements.TryGetValue(chunk, out ret))
                return ret;
            ret = new List<IIndexedElement>();
            BaseElements.Add(chunk, ret);
            return ret;
        }

        public void MoveElementBetweenChunks(IIndexedElement element, IntVector2 oldPosition, IntVector2 newPosition)
        {
            RemoveElement(element, oldPosition);
            AddElement(element, newPosition);
        }

        private void AddElement(IIndexedElement element, IntVector2 newPosition)
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

        private void RemoveElement(IIndexedElement element, IntVector2 oldPosition)
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
        public void Move(IIndexedElement element, Vector3 Position)
        {
            var oldBasePosition = CurrentPositions[element];
            var newBasePosition = GetBasePosition(Position);
            if (oldBasePosition == newBasePosition)
                return;
            MoveElementBetweenChunks(element, oldBasePosition, newBasePosition);
        }
    }
}