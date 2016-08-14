
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandUnityViewFactory
    {
        private GameObjectManager gB= new GameObjectManager();
        public GameObject GetIslandVisualization()
        {
            return gB.LoadViaResources("Island");
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
        }
    }

}