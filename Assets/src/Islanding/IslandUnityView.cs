using UnityEngine;

namespace DarkIslands
{
    public partial class IslandUnityView
    {
        public Island Island { get; set; }
        public GameObject UIIsland { get; set; }
        public IslandUnityViewFactory IslandUnityViewFactory { get; set; }
        public override void Init(Island island, IslandUnityViewFactory fac)
        {
            this.Island = island;
            this.UIIsland= fac.GetIslandVisualization();
            this.IslandUnityViewFactory = fac;
        }

        public override void PositionChanged()
        {
            this.UIIsland.transform.position= Island.Position;
        }

        public override void SizeChanged()
        {
            this.UIIsland.transform.localScale= new Vector3(Island.Size, Island.Size, Island.Size);
        }

        public override void Destroy()
        {
            this.IslandUnityViewFactory.Destroy(UIIsland);
        }
    }
}