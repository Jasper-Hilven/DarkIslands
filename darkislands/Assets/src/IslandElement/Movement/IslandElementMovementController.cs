﻿using System;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementMovementController
    {
        public IslandElement IslandElement { get; set; }
        private IslandElementMovementControllerFactory fac;

        public override void Init(IslandElement IslandElement, IslandElementMovementControllerFactory IslandElementMovementControllerFactory)
        {

            this.fac = IslandElementMovementControllerFactory;
            this.IslandElement = IslandElement;
            IslandElement.MovementController = this;
        }

        public override void RelativeToContainerPositionChanged()
        {
            FixPosition();
        }

        private void CheckIfArrivedInContainer(float arrivalDistance)
        {
            if (!IslandElement.HasRelativeGoalPosition)
                return;
            var goalDistance = this.IslandElement.RelativeToContainerPosition - this.IslandElement.RelativeGoalPosition;
            if (goalDistance.sqrMagnitude < arrivalDistance)
                this.IslandElement.HasRelativeGoalPosition = false;
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

        public void Update(float deltaTime,float arrivalDistance)
        {
            if (!IslandElement.HasRelativeGoalPosition)
                return;
            if (this.IslandElement.Island == null)
                return;
            var oldPosition = this.IslandElement.RelativeToContainerPosition;
            var goalDistance = this.IslandElement.RelativeGoalPosition - oldPosition;
            var maxMovement = this.IslandElement.MaxSpeed * deltaTime;
            if (goalDistance.sqrMagnitude < maxMovement * maxMovement)
            {
                this.IslandElement.RelativeGoalPosition = this.IslandElement.RelativeGoalPosition;
                return;
            }
            goalDistance.Normalize();
            var movement = maxMovement * goalDistance.normalized;
            var newPosition = oldPosition + movement;
            var moveElementWithoutColliding = IslandElement.Island.IslandCollision.MoveElementWithoutColliding(IslandElement, oldPosition,
                newPosition);
            this.IslandElement.RelativeToContainerPosition =
                   new Vector3(moveElementWithoutColliding.x,0,moveElementWithoutColliding.z);

        }

        

        public override void Destroy()
        {
        }
    }
}