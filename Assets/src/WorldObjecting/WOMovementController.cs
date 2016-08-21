namespace DarkIslands
{
    public partial class WOMovementController
    {
        public override void Init(WorldObject WorldObject, WOMovementControllerFactory WOMovementControllerFactory)
        {
            this.WorldObject = WorldObject;
        }

        public WorldObject WorldObject { get; set; }

        public override void ContainerPositionChanged()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            this.WorldObject.Position = WorldObject.ContainerPosition + WorldObject.RelativePosition;
        }

        public override void RelativePositionChanged()
        {
            UpdatePosition();
        }
    }
}