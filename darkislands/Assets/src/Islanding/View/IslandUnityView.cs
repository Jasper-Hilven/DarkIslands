﻿using UnityEngine;

namespace DarkIslands
{
    public partial class IslandUnityView
    {
        public Island Island { get; set; }
        public GameObject UIIsland { get; set; }
        public IslandUnityViewFactory IslandUnityViewFactory { get; set; }
        public override void Init(Island island, IslandUnityViewFactory fac)
        {
            Island = island;
            UIIsland= fac.GetIslandVisualization(island);
            IslandUnityViewFactory = fac;
            UIIsland.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow,Color.gray,0.5f);
           
        }

        public override void PositionChanged()
        {
            UIIsland.transform.position= Island.Position;
        }

        public override void SizeChanged()
        {
            var size = Island.Size;
            size = size < 0 ? 0 : size;
            UIIsland.transform.localScale= new Vector3(size*2, 0.1f, size * 2);
        }

        public override void Destroy()
        {
            IslandUnityViewFactory.Destroy(UIIsland);
        }
    }
}