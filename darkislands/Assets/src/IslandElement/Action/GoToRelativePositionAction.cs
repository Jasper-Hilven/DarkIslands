using UnityEngine;

namespace DarkIslands
{
    public class GoToRelativePositionAction : IIslandElementAction
    {
        public Vector3 RelativePosition { get; set; }
        public Island Island { get; set; }
        private Vector3 CurrentIslandRelativeGoalPosition { get; set; }
        private float arrivedDistance;
        public GoToRelativePositionAction(Vector3 relativePosition, Island island, float arrivedDistance)
        {
            this.arrivedDistance = arrivedDistance;
            this.RelativePosition = relativePosition;
            this.Island = island;
        }


        public bool Update(IslandElement unit, float deltaTime)
        {
            if (unit.Island == null)
                return true;
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
            unit.MovementController.Update(deltaTime, arrivedDistance);
            var onsame = this.Island == unit.Island;
            if (onsame)
                return onsame && !unit.HasRelativeGoalPosition;
            return onsame && !unit.HasRelativeGoalPosition;
        }

        private void SetGoalPositionTowardsOtherIsland(IslandElement unit)
        {
            var jumpDistance = unit.MaxSpeed / 2;
            var maxDistance = (Island.Size + jumpDistance);
            var canJump = (unit.Position - Island.Position).sqrMagnitude < maxDistance * maxDistance;
            if (canJump)
            {
                unit.IslandManager.EnterIsland(Island);
                return;
            }

            var currentIslandRelativeGoalPosition = RelativePosition + Island.Position - unit.IslandPosition;
            var curIslandRelGoalPosLimit = (currentIslandRelativeGoalPosition.sqrMagnitude > unit.Island.Size * unit.Island.Size)
                ? currentIslandRelativeGoalPosition.normalized * unit.Island.Size
                : currentIslandRelativeGoalPosition;
            CurrentIslandRelativeGoalPosition = curIslandRelGoalPosLimit;
        }
    }
}