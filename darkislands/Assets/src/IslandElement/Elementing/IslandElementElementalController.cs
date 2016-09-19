namespace DarkIslands
{
    public partial class IslandElementElementalController
    {
        private IslandElement elem;

        public override void Init(IslandElement IslandElement, IslandElementElementalControllerFactory IslandElementElementalControllerFactory)
        {
            this.elem = IslandElement;
            elem.ElementalController = this;
            base.Init(IslandElement, IslandElementElementalControllerFactory);
        }

        public void SetInfo(ElementalInfo info)
        {
            elem.ElementalInfo = info;

        }

        public void SetInfo(ElementalInfo info, IElementalType type, bool hasView= false)
        {
            SetInfo(info);
            elem.ElementalType = type;
            elem.hasElementalView = hasView;
        }
    }
}