using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class UnitMovementController
    {
        public Unit Unit { get; set; }
        private float arrivalDistance = 0.1f * 0.1f;
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
                this.Unit.RelativeToContainerPosition = ProjectRelativePositionToContainer(relativePosition);
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

        private Vector3 ProjectRelativePositionToContainer(Vector3 relativePosition)
        {
            if (Unit.Container == null)
                return relativePosition;
            var containerAsIsland = Unit.Container as Island;
            if (containerAsIsland != null)
                return ProjectRelativePositionToIsland(relativePosition);
            var containerAsShip = Unit.Container as Ship;
            if (containerAsShip != null)
                return ProjectRelativePositionToShip(relativePosition);
            throw new Exception("Container type not known");
        }

        private Vector3 ProjectRelativePositionToShip(Vector3 relativePosition)
        {
            var maxDistanceFromShip = 0.5f;
            var maxDistanceFromShipSq = maxDistanceFromShip * maxDistanceFromShip;
            var visitingIsland = Unit.Container as Ship;
            var y = 0;
            var xDist = relativePosition.x;
            var zDist = relativePosition.z;
            var awayFromCenterSq = xDist * xDist + zDist * zDist;
            if (awayFromCenterSq <= maxDistanceFromShipSq)
                return new Vector3(relativePosition.x, y, relativePosition.z);
            var reductionFactor = maxDistanceFromShip / ((float)Math.Sqrt(awayFromCenterSq));
            var x = xDist * reductionFactor;
            var z = zDist * reductionFactor;
            return new Vector3(x, y, z);
        }

        private Vector3 ProjectRelativePositionToIsland(Vector3 relativePosition)
        {
            var visitingIsland = Unit.Container as Island;
            var y = 0;
            var xDist = relativePosition.x;
            var zDist = relativePosition.z;
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
                this.Unit.RelativeGoalPosition = this.Unit.RelativeGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement * goalDistance.normalized;
            var newPosition = this.Unit.RelativeToContainerPosition + movement;
            this.Unit.RelativeToContainerPosition = ProjectRelativePositionToContainer(newPosition);
        }

        public override void Destroy()
        {
            this.fac.MovingElements.Remove(this);
        }
    }
}