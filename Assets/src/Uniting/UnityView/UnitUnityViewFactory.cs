using UnityEngine;

namespace DarkIslands
{
    public partial class UnitUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        public GameObject GetUnitVisualization()
        {
            var go= gB.LoadViaResources("Unit");
            go.transform.localScale= new Vector3(1f,1.7f,1f);
            return go;
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
        }

    }
}