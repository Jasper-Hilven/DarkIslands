using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class ContainerControllerIsland
    {
        public List<IslandElement> IslandElements = new List<IslandElement>();
        public override void Init(Island Island, ContainerControllerIslandFactory ContainerControllerIslandFactory)
        {
            Island.ContainerControllerIsland = this;
            this.Island = Island;
            base.Init(Island, ContainerControllerIslandFactory);
        }

        public Island Island { get; set; }


       

        public void AddElement(IslandElement unit)
        {
            if (unit.Island != null)
                return;
            IslandElements.Add(unit);
            Island.IslandCollision.AddElement(unit);
            unit.Island = Island;
        }

        public void RemoveElement(IslandElement unit)
        {
            if (unit.Island != Island)
                return;
            unit.Island = null;
            Island.IslandCollision.RemoveElement(unit);
            IslandElements.Remove(unit);
        }

        public void MoveElement(IslandElement islandElement, Vector3 newPosition)
        {
            Island.IslandCollision.MoveElement(islandElement,newPosition);
        }

        public List<IslandElement> GetContainingUnits
        { get {return IslandElements.ToList();} }

        public bool CanMoveForUnit(IslandElement unit)
        {
            return false;
        }
        public override void PositionChanged()
        {
            foreach (var unit in GetContainingUnits)
            {
                unit.IslandPosition = Island.Position;
            }
        }

        public void SetDestination(Vector3 pos)
        {
            throw new NotImplementedException();
        }

    }
}