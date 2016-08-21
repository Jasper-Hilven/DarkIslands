using System;
using UnityEngine;

namespace DarkIslands
{
    public class EmbarkShipToIslandAction : IUnitAction
    {
        private Vector3 relativeIslandPosition;
        private Island island;

        public EmbarkShipToIslandAction(Vector3 absoluteIslandPosition, Island island)
        {
            relativeIslandPosition = absoluteIslandPosition - island.Position;
            this.island = island;   
        }

        public void Update(Unit unit,float deltaTime)
        {
            var currentShip = unit.Container as Ship;
            if (currentShip == null)
            {
                unit.CurrentAction = null;
                return;
            }
            var intendedPosition = island.Position + relativeIslandPosition;
            if ((currentShip.Position - intendedPosition).sqrMagnitude > 0.01f)
            {
                currentShip.GoalPosition = intendedPosition;
                if (!currentShip.HasGoalPosition)
                    currentShip.HasGoalPosition = true;

            }
            else
            {
                unit.ContainerToEnter = island;
                unit.CurrentAction = null;
            }


        }
    }
}