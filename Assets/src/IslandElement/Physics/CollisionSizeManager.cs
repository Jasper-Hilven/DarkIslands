namespace DarkIslands
{
    public partial class CollisionSizeManager
    {
        private CollisionSizeManagerFactory fac;
        public IslandElement IslandElement { get; set; }

        public override void Init(IslandElement IslandElement, CollisionSizeManagerFactory CollisionSizeManagerFactory)
        {
            this.IslandElement = IslandElement;
            this.fac = CollisionSizeManagerFactory;
            base.Init(IslandElement, CollisionSizeManagerFactory);
        }


        public override void SizeChanged()
        {
            if (this.IslandElement.CircleElementProperties == null)
                return;
            var origRadius = this.IslandElement.CircleElementProperties.OriginalRadius;
            this.IslandElement.CircleElementProperties= new CircleElementProperties(origRadius*this.IslandElement.Size,origRadius);
        }
    }
}