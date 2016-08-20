using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands
{
    public class GameObjectManager : MonoBehaviour
    {
        private Dictionary<string, GameObject> resources = new Dictionary<string, GameObject>();
        public void DestroyObj(GameObject gO)
        {
            Destroy(gO);
        }

        public GameObject LoadViaResources(string path)
        {
            if (!resources.ContainsKey(path))
                resources.Add(path, (Resources.Load(path) as GameObject));
            return Instantiate(resources[path]);
        }
    }
}