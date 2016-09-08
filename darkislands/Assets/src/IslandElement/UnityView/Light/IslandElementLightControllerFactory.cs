using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementLightControllerFactory
    {
        private GameObjectManager gO= new GameObjectManager();
        public GameObject GetLight()
        {
            var obj= gO.LoadViaResources("UnitLight");
            var light= obj.GetComponent<Light>();
            light.color = new Color(1, 1, 1);
            return obj;
        }

        public void DestroyLight(GameObject unitLight)
        {
            gO.DestroyObj(unitLight);
        }
    }
}