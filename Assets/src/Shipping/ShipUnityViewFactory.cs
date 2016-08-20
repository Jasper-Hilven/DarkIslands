using UnityEngine;

namespace DarkIslands
{
    public partial class ShipUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        public GameObject GetShipVisualization(Ship ship)
        {
            var gO = gB.LoadViaResources("Ship");
            this.ModelToEntity.modelToEntity.Add(gO, ship);
            return gO;
        }
        public void Destroy(GameObject gObject)
        {
            this.ModelToEntity.modelToEntity.Remove(gObject);
            gB.DestroyObj(gObject);
        }
    }
}