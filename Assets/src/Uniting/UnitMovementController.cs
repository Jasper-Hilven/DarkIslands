using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class UnitMovementController
    {
        public Unit Unit { get; set; }
        private bool GoingSomewhere { get { return Unit.intendedToMove; } }
        private float arrivalDistance = 0.01f * 0.01f;
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

        public override void VisitingIslandChanged()
        {
            this.Unit.Position = ProjectPositionToIsland(this.Unit.Position);
        }

        private Vector3 ProjectPositionToIsland(Vector3 position)
        {
            var visitingIsland = Unit.VisitingIsland;
            if (visitingIsland == null)
                return position;
            var y = visitingIsland.Position.y;
            var xDist = position.x - visitingIsland.Position.x ;
            var zDist =   position.z - visitingIsland.Position.z;
            var awayFromCenter = xDist * xDist + zDist * zDist;
            if (awayFromCenter <= visitingIsland.Size * visitingIsland.Size)
                return new Vector3(position.x,y,position.z);
            var reductionFactor = visitingIsland.Size / ((float)Math.Sqrt(awayFromCenter));
            var x = visitingIsland.Position.x + xDist * reductionFactor;
            var z = visitingIsland.Position.z + zDist * reductionFactor;
            return new Vector3(x,y,z);
        }

        public void Update(float deltaTime)
        {
            if (!GoingSomewhere)
                return;
            var goalDistance = this.Unit.intendedGoalPosition - this.Unit.Position;
            var maxMovement = this.Unit.MaxSpeed * deltaTime;
            if (goalDistance.sqrMagnitude < maxMovement * maxMovement)
            {
                this.Unit.Position = this.Unit.intendedGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement * goalDistance.normalized;
            var newPosition= this.Unit.Position + movement;
            this.Unit.Position = ProjectPositionToIsland(newPosition);
        }

        public override void Destroy()
        {
            this.fac.MovingElements.Remove(this);
        }
    }
}