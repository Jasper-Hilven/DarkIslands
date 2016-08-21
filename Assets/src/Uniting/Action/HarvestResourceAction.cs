namespace DarkIslands
{
    public class HarvestResourceAction : IUnitAction
    {
        private WorldObject resource;
        private float harvestTime = 0f;
        public HarvestResourceAction(Unit unit, WorldObject resource)
        {
            this.resource = resource;
        }

        public void Update(Unit unit, float deltaTime)
        {
            if ((unit.Position - resource.Position).sqrMagnitude > 0.01)
            {
                harvestTime = 0f;
                unit.RelativeGoalPosition = resource.RelativePosition;
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