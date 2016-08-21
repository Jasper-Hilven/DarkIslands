using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionAction:IUnitAction
    {
        private Vector3 relativePosition;

        public GoToRelativePositionAction(Vector3 relativePosition)
        {
            this.relativePosition = relativePosition;
        }
        public void Update(Unit unit, float deltaTime)
        {
            if (unit.RelativeGoalPosition != relativePosition)
            {
                unit.RelativeGoalPosition = relativePosition;
                unit.HasRelativeGoalPosition = true;
            }
            else
                unit.CurrentAction = null;
        }
    }
}