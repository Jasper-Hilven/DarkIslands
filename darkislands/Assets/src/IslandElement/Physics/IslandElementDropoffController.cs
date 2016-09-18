namespace DarkIslands
{
    public partial class IslandElementDropOffController
    {
        public IslandElementDropOffControllerFactory Fac { get; set; }
        public IslandElement IslandElement { get; set; }
        private float safeTime;
        public override void Init(IslandElement IslandElement, IslandElementDropOffControllerFactory IslandElementDropOffControllerFactory)
        {
            this.IslandElement = IslandElement;
            this.Fac = IslandElementDropOffControllerFactory;
            IslandElement.DropOffController = this;
            base.Init(IslandElement, IslandElementDropOffControllerFactory);
            safeTime = 0;
        }

        public override void RelativeToContainerPositionChanged()
        {
            var safeDistance = (this.IslandElement.Island.Size +2*this.IslandElement.MaxSpeed);
            if ((this.IslandElement.RelativeToContainerPosition.sqrMagnitude) <=
                safeDistance* safeDistance)
                return;
            this.IslandElement.ActionHandler.AddLifeAction(new DropOffAction());
        }


    public void DoDropOffIfOffIsland()
        {
            if (this.IslandElement.RelativeToContainerPosition.sqrMagnitude <=
                this.IslandElement.Island.Size*this.IslandElement.Island.Size)
                return;
            this.IslandElement.ActionHandler.AddLifeAction(new DropOffAction());
        }
    }
}