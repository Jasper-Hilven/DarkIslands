namespace DarkIslands
{
    public class HarvestResourceAction : IIslandElementAction
    {
        public enum HarvestAction{ Chop,Mine,Smash}
        private IslandElement resource;
        private float harvestTime = 0f;
        private IslandElement unit;
        private HarvestAction action;

        public HarvestResourceAction(IslandElement unit, IslandElement resource, HarvestAction action)
        {
            this.unit = unit;
            this.resource = resource;
            this.action = action;
        }

        private void stopHarvesting()
        {
            this.unit.CurrentAction = null;
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
            if (!unit.HarvestInfo.CanHarvest(action) || !resource.HarvestInfo.CanBeHarvested(action))
            {
                stopHarvesting();
                return;
            }
            if (harvestTime < 1f)
            {
                harvestTime += deltaTime;
                return;
            }
            
            harvestTime -= 1f;
            var resHarvested= resource.HarvestController.Harvest(1f);
            unit.InventoryController.AddResource(resHarvested);

        }
    }
}