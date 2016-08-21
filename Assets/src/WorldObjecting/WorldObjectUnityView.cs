using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DarkIslands
{
    public partial class WorldObjectUnityView
    {
        public WorldObjectUnityViewFactory WorldObjectUnityViewFactory { get; set; }
        public WorldObject WorldObject { get; set; }
        public GameObject WorldObjectUI { get; set; }
        public override void Init(WorldObject WorldObject, WorldObjectUnityViewFactory WorldObjectUnityViewFactory)
        {
            this.WorldObjectUnityViewFactory = WorldObjectUnityViewFactory;
            this.WorldObject = WorldObject;
            base.Init(WorldObject, WorldObjectUnityViewFactory);
        }


        public override void TypeChanged()
        {
            if (WorldObjectUI != null || WorldObject.Type == null)
                return;
            if (WorldObject.Type == WorldObjectType.Tree)
            {
                WorldObjectUI= WorldObjectUnityViewFactory.GetTreeVisualization(WorldObject);
            }
        }

        public override void PositionChanged()
        {
            this.WorldObjectUI.transform.position = WorldObject.Position;
        }

        public override void Destroy()
        {
            WorldObjectUnityViewFactory.Destroy(WorldObjectUI);
        }
    }
}
