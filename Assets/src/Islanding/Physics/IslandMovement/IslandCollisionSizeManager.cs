namespace DarkIslands
{
    public partial class IslandCollisionSizeManager
    {
        public override void Init(Island Island, IslandCollisionSizeManagerFactory IslandCollisionSizeManagerFactory)
        {
            this.Island = Island;
            base.Init(Island, IslandCollisionSizeManagerFactory);
        }

        public Island Island { get; set; }

        public override void SizeChanged()
        {
            var oldProps = this.Island.CircleElementProperties ?? new CircleElementProperties(this.Island.Size, this.Island.Size);
            this.Island.CircleElementProperties= new CircleElementProperties(this.Island.Size,oldProps.OriginalRadius);
        }
    }
}