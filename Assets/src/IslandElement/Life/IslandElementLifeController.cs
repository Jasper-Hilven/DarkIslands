namespace DarkIslands
{
    public partial class IslandElementLifeController
    {
        private IslandElement elem;

        public override void Init(IslandElement IslandElement, IslandElementLifeControllerFactory IslandElementLifeControllerFactory)
        {
            this.elem = IslandElement;
            this.elem.LifeController = this;
        }

        public void DieDueToFalling()
        {
            elem.IsAlive = false;
            elem.Factory.DestroyIslandElement(elem);
        }

    }
}