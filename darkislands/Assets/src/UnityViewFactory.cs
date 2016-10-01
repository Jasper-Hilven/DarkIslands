using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DarkIslands
{
    public class UnityViewFactory
    {
        static readonly Color brown = new Color(165 / 255f, 42 / 255f, 42 / 255f);
        private GameObjectManager gB = new GameObjectManager();
        private bool useSimpleObjects = true;
        internal GameObject GetTreeVisualization(int seed)
        {
            var side = (seed % 2) > 0 ? "A" : "B";
            var treeNb = 1 + (seed % 5);
            var treePath = useSimpleObjects ? "Tree" : ("Tree0" + treeNb + side);
            var gO = gB.LoadViaResources(treePath);
            if (useSimpleObjects)
            {
                gO.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material.color = brown;
                gO.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            if (!useSimpleObjects)
            {
                gO.transform.Rotate(new Vector3(0, 0, 1), seed % 360);
            }
            return gO;
        }

        public GameObject GetUnitVisualization()
        {
            var go = gB.LoadViaResources("Man");
            return go;
        }

        internal GameObject GetRockVisualization(bool big, int seed)
        {
            var rockNb = big ? 0 : 1;
            var gO = gB.LoadViaResources(useSimpleObjects ? "Rock" : ("Rock" + rockNb));
            if (useSimpleObjects)
            {
                gO.GetComponent<MeshRenderer>().material.color = Color.gray;
            }
            if (!useSimpleObjects)
            {
                gO.transform.Rotate(new Vector3(0, 1, 0), seed % 360);
            }
            return gO;
        }

        internal GameObject GetBrownMushroomVisualization(int seed)
        {
            var nb = seed % 2;
            var gO = gB.LoadViaResources(useSimpleObjects ? "Mushroom" : ("MushroomBrown" + nb));
            if (useSimpleObjects)
            {
                var child = gO.transform.GetChild(1).gameObject;
                child.GetComponent<MeshRenderer>().material.color = brown;
            }
            if (!useSimpleObjects)
            {
                gO.transform.Rotate(new Vector3(0, 1, 0), seed % 360);
                gO.transform.localScale = new Vector3(10, 10, 10);
            }
            return gO;
        }

        internal GameObject GetGrassVisualization(int seed)
        {
            var nb = seed % 4;
            var gO = gB.LoadViaResources("Grass" + (useSimpleObjects ? "" : ("" + nb)));
            gO.transform.Rotate(new Vector3(0, 1, 0), seed % 360);
            if (useSimpleObjects)
            {
                gO.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            gO.transform.localScale = new Vector3(2, 3, 2);
            return gO;
        }

        internal GameObject GetWizardVisualization()
        {
            var go = gB.LoadViaResources("Man");
            return go;
        }

        public GameObject GetSkeletonVisualization()
        {
            var go = gB.LoadViaResources("Man");
            return go;
        }

        public GameObject GetFighterVisualization()
        {
            var go = gB.LoadViaResources("Man");
            return go;
        }

        internal GameObject GetWoodVisualization()
        {
            var gO = gB.LoadViaResources("Wood");
            var child = gO.transform.GetChild(1).gameObject;
            child.GetComponent<MeshRenderer>().material.color = brown;
            return gO;
         }

        internal GameObject GetStoneVisualization()
        {
            throw new NotImplementedException();
        }
        public void Destroy(GameObject gObject)
        {
            gB.DestroyObj(gObject);
        }
    }
}
