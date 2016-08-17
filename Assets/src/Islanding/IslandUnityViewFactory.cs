
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class IslandUnityViewFactory
    {
        private GameObjectManager gB= new GameObjectManager();
        public GameObject GetIslandVisualization(Island island)
        {
            var gb= gB.LoadViaResources("Island");
            this.ModelToEntity.modelToEntity.Add(gb,island);
            return gb;
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
            this.ModelToEntity.modelToEntity.Remove(gObject);
        }
    }

}