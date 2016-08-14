using System;

namespace DarkIslands
{
    public partial class UnitMovementController
    {
        public Unit Unit { get; set; }
        private bool GoingSomewhere { get { return Unit.intendedToMove; } }
        private float arrivalDistance = 0.1f* 0.1f;
        private UnitMovementControllerFactory fac;

        public override void Init(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory)
        {
            this.fac = UnitMovementControllerFactory;
            this.Unit = Unit;
        }
        public override void PositionChanged()
        {
         CheckIfArrived();   
        }

        private void CheckIfArrived()
        {
            if (!GoingSomewhere)
                return;
            var goalDistance = this.Unit.Position - this.Unit.intendedGoalPosition;
            if (goalDistance.sqrMagnitude < arrivalDistance)
                this.Unit.intendedToMove = false;
        }
        public override void intendedGoalPositionChanged()
        {
            CheckIfArrived();
        }

        public override void intendedToMoveChanged()
        {
            if (GoingSomewhere && !this.fac.MovingElements.Contains(this))
                fac.MovingElements.Add(this);
            if (!GoingSomewhere && this.fac.MovingElements.Contains(this))
                fac.MovingElements.Remove(this);
        }

        public void Update(float deltaTime)
        {
            if (!GoingSomewhere)
                return;
            var goalDistance= this.Unit.intendedGoalPosition - this.Unit.Position;
            var maxMovement = this.Unit.MaxSpeed*deltaTime;
            if (goalDistance.sqrMagnitude < maxMovement*maxMovement)
            {
                this.Unit.Position = this.Unit.intendedGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement* goalDistance.normalized;
            this.Unit.Position += movement;
        }

        public override void Destroy()
        {
            this.fac.MovingElements.Remove(this);
        }
    }
}