using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionAction: IIslandElementAction
    {
        private Vector3 relativePosition;

        public GoToRelativePositionAction(Vector3 relativePosition)
        {
            this.relativePosition = relativePosition;
        }
        public void Update(IslandElement unit, float deltaTime)
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