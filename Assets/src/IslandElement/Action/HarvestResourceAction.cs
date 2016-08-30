﻿namespace DarkIslands
{
    public class HarvestResourceAction : IIslandElementAction
    {
        private IslandElement resource;
        private float harvestTime = 0f;
        public HarvestResourceAction(IslandElement unit, IslandElement resource)
        {
            this.resource = resource;
        }

        public void Update(IslandElement unit, float deltaTime)
        {
            if ((unit.Position - resource.Position).sqrMagnitude > 0.01)
            {
                harvestTime = 0f;
                unit.RelativeGoalPosition = resource.RelativeToContainerPosition;
                unit.HasRelativeGoalPosition = true;
                return;
            }
            if (harvestTime < 1f)
            {
                harvestTime += deltaTime;
                return;
            }
            
        }
    }
}