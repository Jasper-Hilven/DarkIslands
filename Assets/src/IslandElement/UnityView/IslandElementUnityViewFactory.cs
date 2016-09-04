using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        private System.Random r = new System.Random();

        public GameObject GetUnitVisualization(IslandElement unit)
        {
            var go= gB.LoadViaResources("Unit");
            this.ModelToEntity.modelToEntity.Add(go, unit);
            return go;
        }
        public GameObject GetTreeVisualization(IslandElement tree, int seed)
        {
            var side = (seed % 2) > 0 ? "A" : "B";
            var treeNb = 1 + (seed % 5);
            var gO = gB.LoadViaResources("Tree0" + treeNb + side);
            gO.transform.Rotate(new Vector3(0, 0, 1), r.Next(360));
            this.ModelToEntity.modelToEntity.Add(gO, tree);
            return gO;
        }
        public void Destroy(GameObject gObject)
        {
            this.ModelToEntity.modelToEntity.Remove(gObject);
            gB.DestroyObj(gObject);
        }


    }
}