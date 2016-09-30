namespace DarkIslands
{
    public class HarvestResourceAction : IIslandElementAction
    {
        public enum HarvestAction{ Chop,Mine,Smash}
        private IslandElement resource;
        private float harvestTime = 0f;
        private HarvestAction action;
        private GoToRelativePositionAction gotoResourceAction;
        public HarvestResourceAction( IslandElement resource, HarvestAction action)
        {
            harvestTime = 0f;
            this.resource = resource;
            this.action = action;
        }
        private const float harvestTimeCost= .5f;
        public bool Update(IslandElement unit, float deltaTime)
        {
            if (!unit.HarvestInfo.CanHarvest(action) || !resource.HarvestInfo.CanBeHarvested(action))
            {
                return true;
            }
            if ((unit.Position - resource.Position).sqrMagnitude > 2.0f)
            {
                harvestTime = 0f;
                if(gotoResourceAction == null || gotoResourceAction.Island != resource.Island || gotoResourceAction.RelativePosition != resource.RelativeToContainerPosition)
                gotoResourceAction = new GoToRelativePositionAction(resource.RelativeToContainerPosition,
                    resource.Island,1.0f);
                gotoResourceAction.Update(unit, deltaTime);
                return false;
            }
            if (harvestTime < harvestTimeCost)
            {
                harvestTime += deltaTime;
                return false;
            }

            harvestTime -= harvestTimeCost;
            unit.HarvestController.Harvest(1f,resource);
            return false;
        }
    }
}