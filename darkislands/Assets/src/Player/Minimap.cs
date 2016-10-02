using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DarkIslands
{
    public class Minimap
    {
        private MinimapCollider viewCollider = new MinimapCollider();
        private FollowCamera toFollow;
        private List<Island> DrawingIslands = new List<Island>();
        private GameObject minimapBase;
        private List<GameObject> DrawingIslandViews = new List<GameObject>();
        private List<float> DrawingSizes = new List<float>();
        private GameObjectManager gOM = new GameObjectManager();
        private float scaleFactor = 0.1f;
        public TopDownCircleSpaceIndex TopdownIslandIndex
        {
            get; set;
        }

        public Minimap(TopDownCircleSpaceIndex TopdownIslandIndex, FollowCamera toFollow)
        {
            this.TopdownIslandIndex = TopdownIslandIndex;
            this.toFollow = toFollow;
            minimapBase = gOM.LoadViaResources("MinimapBase");
        }

        public void Update()
        {
            var closeIslands = TopdownIslandIndex.GetColliders(viewCollider, toFollow.GetPosition());
            var toAdd = closeIslands.Where(i => !DrawingIslands.Contains((Island)i));
            foreach (var item in toAdd)
                AddIsland((Island)item);
            var toDelete = DrawingIslands.Where(i => !closeIslands.Contains(i));
            foreach (var item in toDelete)
                DeleteIsland((Island)item);
            UpdateSizes();
            UpdatePositions();
        }

        private void UpdateSizes()
        {
            for (int i = 0; i < DrawingSizes.Count; i++)
            {
                var island = DrawingIslands[i];
                if (island == null)
                    continue;
                if (island.Size == DrawingSizes[i])
                    continue;
                DrawingSizes[i] = island.Size;
                DrawingIslandViews[i].transform.localScale = new Vector3(island.Size * scaleFactor, 1, island.Size * scaleFactor);
            }
        }
        private Vector3 GetMinimapPosition()
        {
            var toFollowPosition = toFollow.GetPosition();
            return toFollowPosition + new Vector3(5, -6, 2.1f);
        }
        private void UpdatePositions()
        {
            var toFollowPosition = toFollow.GetToFollowPosition();
            var minimapPos = GetMinimapPosition();
            minimapBase.transform.localPosition = minimapPos;
            for (int i = 0; i < DrawingSizes.Count; i++)
            {
                var island = DrawingIslands[i];
                if (island == null)
                    continue;
                var relativeIslandPosition = island.Position - toFollowPosition;
                DrawingIslandViews[i].transform.localPosition = new Vector3(0, .1f, 0) + minimapPos + relativeIslandPosition * scaleFactor*0.1f;
            }
        }

        private void DeleteIsland(Island island)
        {
            var index = DrawingIslands.IndexOf(island);
            if (index == -1)
                return;
            DrawingIslands[index] = null;
            gOM.DestroyObj(DrawingIslandViews[index]);
            DrawingIslandViews[index] = null;
            DrawingSizes[index] = -1f;
        }

        private void AddIsland(Island island)
        {
            var index = DrawingIslands.IndexOf(null);
            if (index == -1)
            {
                index = DrawingIslands.Count;
                DrawingIslands.Add(null);
                DrawingIslandViews.Add(null);
                DrawingSizes.Add(-1);
            }
            DrawingIslands[index] = island;
            DrawingIslandViews[index] = gOM.LoadViaResources("IslandMinimap");
            var child = DrawingIslandViews[index].transform.GetChild(0).gameObject;
            child.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }



    }
    public class MinimapCollider : ICircleElement
    {
        private CircleElementProperties props = new CircleElementProperties(500, 500);
        public CircleElementProperties CircleElementProperties
        {
            get
            {
                return props;
            }
        }

        public Vector3 IndexPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
