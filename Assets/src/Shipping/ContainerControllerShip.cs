using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class ContainerControllerShip : UnitContainerController
    {
        public List<Unit> units = new List<Unit>();
        public override void Init(Ship Ship, ContainerControllerShipFactory ContainerControllerShipFactory)
        {
            this.Ship = Ship;
            Ship.UnitContainerController = this;
            base.Init(Ship, ContainerControllerShipFactory);
        }

        public Ship Ship { get; set; }

        public bool CanAddUnit(Unit unit)
        {
            return true;
        }

        public void AddUnit(Unit unit)
        {
            if (unit.Container != null)
                return;
            units.Add(unit);
            unit.Container = this.Ship;
        }

        public void RemoveUnit(Unit unit)
        {
            if (unit.Container != Ship)
                return;
            unit.Container = null;
            units.Remove(unit);
        }

        public bool CanMoveForUnit(Unit unit)
        {
            return units.Contains(unit);
        }

        public void SetDestination(Vector3 pos)
        {
            throw new NotImplementedException();
        }
    }
}