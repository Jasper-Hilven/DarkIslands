using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public partial class ContainingUnitsController
    {
        public override void Init(Ship Ship, ContainingUnitsControllerFactory ContainingUnitsControllerFactory)
        {
            this.Ship = Ship;
        }

        public Ship Ship { get; set; }

        public override void ContainingUnitsChanged()
        {
            UpdateContainingUnits();
        }

        public override void PositionChanged()
        {
            UpdateContainingUnits();
        }

        private void UpdateContainingUnits()
        {
            if (Ship.ContainingUnits == null)
            {
                Ship.ContainingUnits = new List<Unit>();
                return;
            }
            for (var i = 0; i < Ship.ContainingUnits.Count; i++)
            {
                var unit = Ship.ContainingUnits[i];
                unit.ContainerPosition = Ship.Position + new Vector3(0.1f * i, 0, 0);
            }

        }
    }
}