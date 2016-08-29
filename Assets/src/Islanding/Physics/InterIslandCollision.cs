namespace DarkIslands
{
    public partial class InterIslandCollision
    {
        private InterIslandCollisionFactory fac;
        public Island Island { get; set; }

        public override void Init(Island Island, InterIslandCollisionFactory InterIslandCollisionFactory)
        {
            this.Island = Island;
            fac = InterIslandCollisionFactory;
            fac.AddIsland(Island);
        }

        public override void Destroy()
        {
            this.fac.RemoveIsland(Island);
        }

        public override void PositionChanged()
        {
            var detectCollision= this.fac.MoveDetectCollision(Island, Island.Position);
        }
    }
}