using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        private System.Random r = new System.Random();

        public GameObject GetUnitVisualization()
        {
            var go= gB.LoadViaResources("Unit");
            return go;
        }
        public GameObject GetTreeVisualization(IslandElement tree)
        {
            var side = r.Next(2) > 0 ? "A" : "B";
            var treeNb = 1 + r.Next(5);
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