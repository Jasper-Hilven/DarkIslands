using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class ContainerControllerIsland:UnitContainerController
    {
        public List<Unit> units = new List<Unit>();
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
            units.Add(unit);
            unit.Container = this.Island;
        }

        public void RemoveUnit(Unit unit)
        {
            if (unit.Container != Island)
                return;
            unit.Container = null;
            units.Remove(unit);
        }

        public bool CanMoveForUnit(Unit unit)
        {
            return units.Contains(unit);
        }
        public override void PositionChanged()
        {
            foreach (var unit in units)
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