
using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public partial class ShipUnityViewFactory
    {
        private GameObjectManager gB= new GameObjectManager();
        public GameObject GetShipVisualization()
        {
            return gB.LoadViaResources("Ship");
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
        }
    }

    public class GameObjectManager : MonoBehaviour
    {
        private Dictionary<string, GameObject> resources =new Dictionary<string, GameObject>();
        public void DestroyObj(GameObject gO)
        {
            Destroy(gO);
        }

        public GameObject LoadViaResources(string path)
        {
            if(!resources.ContainsKey(path))
                resources.Add(path, (Resources.Load(path) as GameObject));
            return Instantiate(resources[path]);
        }
    }
}