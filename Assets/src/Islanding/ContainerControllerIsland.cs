using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class ContainerControllerIsland:UnitContainerController
    {
        public List<Unit> Units = new List<Unit>();
        public override void Init(Island Island, ContainerControllerIslandFactory ContainerControllerIslandFactory)
        {
            Island.UnitContainerController = this;
            this.Island = Island;
            base.Init(Island, ContainerControllerIslandFactory);

        }


        public IUnitContainer Island { get; set; }

        public bool CanAddUnit(Unit unit)
        {
            return true;
        }

        public void AddUnit(Unit unit)
        {
            if (unit.Container != null)
                return;
            Units.Add(unit);
            unit.Container = Island;
        }

        public void RemoveUnit(Unit unit)
        {
            if (unit.Container != Island)
                return;
            unit.Container = null;
            Units.Remove(unit);
        }

        public List<Unit> GetContainingUnits
        { get {return Units.ToList();} }

        public bool CanMoveForUnit(Unit unit)
        {
            return Units.Contains(unit);
        }
        public override void PositionChanged()
        {
            foreach (var unit in Units)
            {
                unit.ContainerPosition = Island.Position;
            }
        }

        public void SetDestination(Vector3 pos)
        {
            throw new NotImplementedException();
        }

    }
}