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
            unit.Island = Island;
        }

        public void RemoveUnit(IslandElement unit)
        {
            if (unit.Island != Island)
                return;
            unit.Island = null;
            IslandElements.Remove(unit);
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