using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public class EnterShipAction : IUnitAction
    {
        private static float enterdistancesSq = 0.5f*0.5f;
        public EnterShipAction(Ship ship)
        {
            this.Ship = ship;
        }

        public Ship Ship { get; set; }
        public void Update(Unit unit,float deltaTime)
        {
            if (unit.RelativeGoalPosition != this.Ship.Position - unit.ContainerPosition)
            {
                unit.RelativeGoalPosition = this.Ship.Position - unit.ContainerPosition;
                unit.HasRelativeGoalPosition = true;
            }
            var distance = unit.Position - this.Ship.Position;
            if (distance.sqrMagnitude < enterdistancesSq)
            {
                
                unit.ContainerToEnter = this.Ship;
                unit.CurrentAction = null;
            }
        }
    }
}