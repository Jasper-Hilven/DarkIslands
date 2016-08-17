using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class UnitMovementController
    {
        public Unit Unit { get; set; }
        private float arrivalDistance = 0.01f * 0.01f;
        private UnitMovementControllerFactory fac;

        public override void Init(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory)
        {
            this.fac = UnitMovementControllerFactory;
            this.Unit = Unit;
        }


        public override void RelativeToContainerPositionChanged()
        {
            CheckIfArrivedInContainer();
            FixPosition();
        }

        private void CheckIfArrivedInContainer()
        {
            if (!Unit.HasRelativeGoalPosition)
                return;
            var goalDistance = this.Unit.RelativeToContainerPosition - this.Unit.RelativeGoalPosition;
            if (goalDistance.sqrMagnitude < arrivalDistance)
                this.Unit.HasRelativeGoalPosition = false;
        }

        public override void RelativeGoalPositionChanged()
        {
            CheckIfArrivedInContainer();
        }

        public override void HasRelativeGoalPositionChanged()
        {
            if (Unit.HasRelativeGoalPosition && !this.fac.MovingElements.Contains(this))
                fac.MovingElements.Add(this);
            if (!Unit.HasRelativeGoalPosition && this.fac.MovingElements.Contains(this))
                fac.MovingElements.Remove(this);
        }

        public override void ContainerChanged()
        {
            Unit.HasRelativeGoalPosition = false;//If we enter or exit a container, stop going somewhere
            var visitingContainer = Unit.Container as IUnitContainer;
            if (visitingContainer != null)
            {

                var relativePosition = Unit.Position - visitingContainer.Position;
                this.Unit.ContainerPosition = visitingContainer.Position;
                this.Unit.RelativeToContainerPosition = ProjectRelativePositionToIsland(relativePosition);
            }
        }

        public override void ContainerPositionChanged()
        {
            if (Unit.Container == null)
                return;
            FixPosition();
        }

        private void FixPosition()
        {
            this.Unit.Position = Unit.ContainerPosition + Unit.RelativeToContainerPosition;
        }

        private Vector3 ProjectRelativePositionToIsland(Vector3 relativePosition)
        {
            var visitingIsland = Unit.Container as Island;
            if (visitingIsland == null)
                return relativePosition;
            var y = 0;
            var xDist = relativePosition.x ;
            var zDist = relativePosition.z ;
            var awayFromCenter = xDist * xDist + zDist * zDist;
            if (awayFromCenter <= visitingIsland.Size * visitingIsland.Size)
                return new Vector3(relativePosition.x, y, relativePosition.z);
            var reductionFactor = visitingIsland.Size / ((float)Math.Sqrt(awayFromCenter));
            var x = xDist * reductionFactor;
            var z = zDist * reductionFactor;
            return new Vector3(x, y, z);
        }

        public void Update(float deltaTime)
        {
            if (!Unit.HasRelativeGoalPosition)
                return;
            if (this.Unit.Container == null)
                return;
            var goalDistance = this.Unit.RelativeGoalPosition - this.Unit.RelativeToContainerPosition;
            var maxMovement = this.Unit.MaxSpeed * deltaTime;
            if (goalDistance.sqrMagnitude < maxMovement * maxMovement)
            {
                this.Unit.RelativeGoalPosition= this.Unit.RelativeGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement * goalDistance.normalized;
            var newPosition = this.Unit.RelativeToContainerPosition + movement;
            this.Unit.RelativeToContainerPosition = ProjectRelativePositionToIsland(newPosition);
        }

        public override void Destroy()
        {
            this.fac.MovingElements.Remove(this);
        }
    }
}