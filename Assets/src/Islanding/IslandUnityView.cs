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
            this.UIIsland.GetComponent<Renderer>().material.color = Color.yellow;
        }

        public override void PositionChanged()
        {
            this.UIIsland.transform.position= Island.Position;
        }

        public override void SizeChanged()
        {
            this.UIIsland.transform.localScale= new Vector3(Island.Size*2, 0.1f, Island.Size * 2);
        }

        public override void Destroy()
        {
            this.IslandUnityViewFactory.Destroy(UIIsland);
        }
    }
}