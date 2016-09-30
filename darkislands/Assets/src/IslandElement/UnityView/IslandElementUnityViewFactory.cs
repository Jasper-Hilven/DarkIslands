using UnityEngine;

namespace DarkIslands
{
    public partial class IslandElementUnityViewFactory
    {
        private GameObjectManager gB = new GameObjectManager();
        private System.Random r = new System.Random();
        private bool useSimpleObjects = true;
        public GameObject GetUnitVisualization(IslandElement unit)
        {
            var go = gB.LoadViaResources("Man");
            this.ModelToEntity.modelToEntity.Add(go, unit);
            return go;
        }
        static readonly Color brown = new Color(165/255f, 42 / 255f, 42 / 255f);
        public GameObject GetTreeVisualization(IslandElement tree, int seed)
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
                gO.transform.Rotate(new Vector3(0, 0, 1), r.Next(360));
            }
            this.ModelToEntity.modelToEntity.Add(gO, tree);
            return gO;
        }

        public GameObject GetRockVisualization(IslandElement rock, bool big)
        {
            var rockNb = big ? 0 : 1;
            var gO = gB.LoadViaResources(useSimpleObjects ? "Rock" : ("Rock" + rockNb));
            if (useSimpleObjects)
            {
                gO.GetComponent<MeshRenderer>().material.color = Color.gray;
            }
            if (!useSimpleObjects)
            {
                gO.transform.Rotate(new Vector3(0, 1, 0), r.Next(360));
            }
            this.ModelToEntity.modelToEntity.Add(gO, rock);
            return gO;
        }

        public GameObject GetGrassVisualization(IslandElement grass)
        {
            var nb = r.Next(0, 3);
            var gO = gB.LoadViaResources("Grass" + (useSimpleObjects ? "": (""+nb)));
            gO.transform.Rotate(new Vector3(0, 1, 0), r.Next(360));
            if (useSimpleObjects)
            {
                gO.GetComponent<MeshRenderer>().material.color=Color.green;
            }
            gO.transform.localScale = new Vector3(2, 3, 2);
            this.ModelToEntity.modelToEntity.Add(gO, grass);
            return gO;
        }

        public GameObject GetBrownMushroomVisualization(IslandElement mushroom)
        {
            var nb = r.Next(0, 2);
            var gO = gB.LoadViaResources(useSimpleObjects ? "Mushroom" : ("MushroomBrown" + nb));
            if (useSimpleObjects)
            {
                var child = gO.transform.GetChild(1).gameObject;
                child.GetComponent<MeshRenderer>().material.color = brown;
            }
            if (!useSimpleObjects)
            {
                gO.transform.Rotate(new Vector3(0, 1, 0), r.Next(360));
                gO.transform.localScale = new Vector3(10, 10, 10);
            }
            this.ModelToEntity.modelToEntity.Add(gO, mushroom);
            return gO;
        }


        public void Destroy(GameObject gObject)
        {
            this.ModelToEntity.modelToEntity.Remove(gObject);
            gB.DestroyObj(gObject);
        }


        public GameObject GetSkeletonVisualization(IslandElement islandElement)
        {
            var go = gB.LoadViaResources("Man");
            this.ModelToEntity.modelToEntity.Add(go, islandElement);
            return go;
        }

        public GameObject GetFighterVisualization(IslandElement islandElement)
        {
            var go = gB.LoadViaResources("Man");
            this.ModelToEntity.modelToEntity.Add(go, islandElement);
            return go;
        }
    }
}