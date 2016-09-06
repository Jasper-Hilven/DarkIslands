namespace DarkIslands
{
    public partial class IslandElementDropOffController
    {
        public IslandElementDropOffControllerFactory Fac { get; set; }
        public IslandElement IslandElement { get; set; }

        public override void Init(IslandElement IslandElement, IslandElementDropOffControllerFactory IslandElementDropOffControllerFactory)
        {
            this.IslandElement = IslandElement;
            this.Fac = IslandElementDropOffControllerFactory;
            IslandElement.DropOffController = this;
            base.Init(IslandElement, IslandElementDropOffControllerFactory);
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