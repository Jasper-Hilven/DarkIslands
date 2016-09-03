using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionAction: IIslandElementAction
    {
        private Vector3 relativePosition;
        public Island Island { get; set; }

        public GoToRelativePositionAction(Vector3 relativePosition,Island island)
        {
            this.relativePosition = relativePosition;
            this.Island = island;
        }


        public void Update(IslandElement unit, float deltaTime)
        {
            if (this.Island != unit.Island)
            {
                
            }
            if (unit.RelativeGoalPosition != relativePosition || unit.HasRelativeGoalPosition == false)
            {
                unit.RelativeGoalPosition = relativePosition;
                unit.HasRelativeGoalPosition = true;
            }
            unit.MovementController.Update(deltaTime);
            if (!unit.HasRelativeGoalPosition)
                unit.CurrentAction = null;
        }
    }
}