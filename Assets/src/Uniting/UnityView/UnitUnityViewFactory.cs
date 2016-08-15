using UnityEngine;

namespace DarkIslands
{
    public partial class UnitUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        public GameObject GetUnitVisualization()
        {
            var go= gB.LoadViaResources("Unit");
            go.transform.localScale= new Vector3(0.3f,0.3f,0.3f);
            return go;
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
        }

    }
}