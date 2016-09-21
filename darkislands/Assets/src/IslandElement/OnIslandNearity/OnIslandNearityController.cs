using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class OnIslandNearityController
    {
        private Island island;
        private OnIslandNearityControllerFactory fac;
        private SpaceIndex index;

        public override void Init(Island Island, OnIslandNearityControllerFactory OnIslandNearityControllerFactory)
        {
            island = Island;
            island.NearityController = this;
            fac = OnIslandNearityControllerFactory;
            index = new SpaceIndex(10);
        }

        public void AddIslandElement(IslandElement element)
        {
            if (element.NearOthersController.IsActive)
                index.Add(element);
        }

        public void RemoveIslandElement(IslandElement element)
        {
            if (element.NearOthersController.IsActive)
                index.Remove(element);
        }

        public void MoveElement(IslandElement islandElement, Vector3 newPosition)
        {
            if (!islandElement.NearOthersController.IsActive)
                return;
            index.Move(islandElement, newPosition);
            var nearElements = GetElementsNear(islandElement);
            foreach (var nearElement in nearElements)
                nearElement.NearOthersController.NotifyChanges();
        }

        public List<IslandElement> GetElementsNear(IslandElement element)
        {
            return
                index.GetElements(element.RelativeToContainerPosition)
                    .Where(e => e != element)
                    .Select(e => (IslandElement) e)
                    .ToList();
        } 
    }
}