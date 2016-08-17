using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public class EnterShipAction : IUnitAction
    {
        public EnterShipAction(Ship ship)
        {
            this.Ship = ship;
        }

        public Ship Ship { get; set; }
        public void Update(Unit unit)
        {
            if (unit.RelativeGoalPosition != this.Ship.Position - unit.ContainerPosition)
            {
                unit.RelativeGoalPosition = this.Ship.Position - unit.ContainerPosition;
                unit.HasRelativeGoalPosition = true;
            }
            var distance = unit.Position - this.Ship.Position;
            if (distance.sqrMagnitude < 1)
            {
                
                unit.ContainerToEnter = this.Ship;
                unit.CurrentAction = null;
            }
        }
    }
}