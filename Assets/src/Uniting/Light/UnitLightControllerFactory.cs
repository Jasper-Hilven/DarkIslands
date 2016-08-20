using UnityEngine;

namespace DarkIslands
{
    public partial class UnitLightControllerFactory
    {
        private GameObjectManager gO= new GameObjectManager();
        public GameObject GetLight()
        {
            return  gO.LoadViaResources("UnitLight");
        }

        public void DestroyLight(GameObject unitLight)
        {
            gO.DestroyObj(unitLight);
        }
    }
}