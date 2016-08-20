using UnityEngine;

namespace DarkIslands
{
    public partial class WorldObjectUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        public GameObject GetTreeVisualization(WorldObject worldObject)
        {
            var gO = gB.LoadViaResources("Tree");
            this.ModelToEntity.modelToEntity.Add(gO, worldObject);
            return gO;
        }
        public void Destroy(GameObject gObject)
        {
            this.ModelToEntity.modelToEntity.Remove(gObject);
            gB.DestroyObj(gObject);
        }

    }
}