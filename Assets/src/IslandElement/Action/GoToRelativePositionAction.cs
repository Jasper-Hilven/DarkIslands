using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionAction: IIslandElementAction
    {
        public Vector3 RelativePosition { get; set; }
        public Island Island { get; set; }
        private Vector3 CurrentIslandRelativeGoalPosition { get; set;}
        private float arrivedDistance;
        private const float jumpDistance = 1f;
        public GoToRelativePositionAction(Vector3 relativePosition,Island island,float arrivedDistance)
        {
            this.arrivedDistance = arrivedDistance;
            this.RelativePosition = relativePosition;
            this.Island = island;
        }


        public bool Update(IslandElement unit, float deltaTime)
        {
            CurrentIslandRelativeGoalPosition = RelativePosition;
            if (this.Island != unit.Island)
            {
                SetGoalPositionTowardsOtherIsland(unit);
            }
            if (unit.RelativeGoalPosition != CurrentIslandRelativeGoalPosition || unit.HasRelativeGoalPosition == false)
            {
                unit.RelativeGoalPosition = CurrentIslandRelativeGoalPosition;
                unit.HasRelativeGoalPosition = true;
            }
            unit.MovementController.Update(deltaTime,arrivedDistance);
            return this.Island == unit.Island && !unit.HasRelativeGoalPosition;
        }

        private void SetGoalPositionTowardsOtherIsland(IslandElement unit)
        {
            var maxDistance = (Island.Size+jumpDistance);
            var canJump = (unit.Position - Island.Position).sqrMagnitude < maxDistance*maxDistance;
            if (canJump)
            {
                unit.IslandToEnter = Island;
                return;
            }
            CurrentIslandRelativeGoalPosition= RelativePosition+Island.Position - unit.IslandPosition;
        }
    }
}