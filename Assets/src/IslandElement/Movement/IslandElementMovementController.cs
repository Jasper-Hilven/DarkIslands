using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementMovementController
    {
        public IslandElement IslandElement { get; set; }
        private float arrivalDistance = 0.1f * 0.1f;
        private IslandElementMovementControllerFactory fac;

        public override void Init(IslandElement IslandElement, IslandElementMovementControllerFactory IslandElementMovementControllerFactory)
        {
            this.fac = IslandElementMovementControllerFactory;
            this.IslandElement = IslandElement;
        }

        public override void RelativeToContainerPositionChanged()
        {
            CheckIfArrivedInContainer();
            FixPosition();
        }

        private void CheckIfArrivedInContainer()
        {
            if (!IslandElement.HasRelativeGoalPosition)
                return;
            var goalDistance = this.IslandElement.RelativeToContainerPosition - this.IslandElement.RelativeGoalPosition;
            if (goalDistance.sqrMagnitude < arrivalDistance)
                this.IslandElement.HasRelativeGoalPosition = false;
        }

        public override void RelativeGoalPositionChanged()
        {
            CheckIfArrivedInContainer();
        }

        public override void HasRelativeGoalPositionChanged()
        {
            if (IslandElement.HasRelativeGoalPosition && !this.fac.MovingElements.Contains(this))
                fac.MovingElements.Add(this);
            if (!IslandElement.HasRelativeGoalPosition && this.fac.MovingElements.Contains(this))
                fac.MovingElements.Remove(this);
        }

        public override void IslandChanged()
        {
            IslandElement.HasRelativeGoalPosition = false;//If we enter or exit a container, stop going somewhere
            var visitingContainer = IslandElement.Island as Island;
            if (visitingContainer != null)
            {

                var relativePosition = IslandElement.Position - visitingContainer.Position;
                this.IslandElement.IslandPosition = visitingContainer.Position;
                this.IslandElement.RelativeToContainerPosition = ProjectRelativePositionToContainer(relativePosition);
            }
        }

        public override void IslandPositionChanged()
        {
            if (IslandElement.Island == null)
                return;
            FixPosition();
        }

        private void FixPosition()
        {
            this.IslandElement.Position = IslandElement.IslandPosition + IslandElement.RelativeToContainerPosition;
        }

        private Vector3 ProjectRelativePositionToContainer(Vector3 relativePosition)
        {
            if (IslandElement.Island == null)
                return relativePosition;
            var containerAsIsland = IslandElement.Island as Island;
            if (containerAsIsland != null)
                return ProjectRelativePositionToIsland(relativePosition);
            throw new Exception("Container type not known");
        }

       
        private Vector3 ProjectRelativePositionToIsland(Vector3 relativePosition)
        {
            var visitingIsland = IslandElement.Island as Island;
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
            if (!IslandElement.HasRelativeGoalPosition)
                return;
            if (this.IslandElement.Island == null)
                return;
            var goalDistance = this.IslandElement.RelativeGoalPosition - this.IslandElement.RelativeToContainerPosition;
            var maxMovement = this.IslandElement.MaxSpeed * deltaTime;
            if (goalDistance.sqrMagnitude < maxMovement * maxMovement)
            {
                this.IslandElement.RelativeGoalPosition = this.IslandElement.RelativeGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement * goalDistance.normalized;
            var newPosition = this.IslandElement.RelativeToContainerPosition + movement;
            this.IslandElement.RelativeToContainerPosition = ProjectRelativePositionToContainer(newPosition);
        }

        public override void Destroy()
        {
            this.fac.MovingElements.Remove(this);
        }
    }
}