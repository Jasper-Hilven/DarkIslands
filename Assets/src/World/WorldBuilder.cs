using System.Collections.Generic;
using UnityEngine;

namespace DarkIslands.World
{
    public class WorldBuilder
    {

        public void BuildWorld(FactoryProvider provider)
        {
            BuildIsland(provider, new Vector3(200, 0, 0), 100f, 2);
            BuildIsland(provider, new Vector3(0, 0, 0), 72f, 2);
        }

        public Island BuildIsland(FactoryProvider provider, Vector3 Position, float size, int seed)
        {
            var island = provider.IslandFactory.Create();
            island.SizeController.SetInitialSize(size);
            island.Position = Position;
            SetTrees(provider,island,new System.Random(seed));
            return island;
            
        }


        public void SetTrees(FactoryProvider provider, Island island, System.Random rand)
        {
            var size = Mathf.RoundToInt(island.Size);
            if (size < 5)
                return;
            var sizeSq = (size - 1)*(size - 1);
            var minsQ = 4*4;
            var sizeBiCub = (size -1)* (size - 1) * size * size;
            var min = 4 * 4 * 4 * 4;
            var nbTrees = size * size / 10+ rand.Next(0, size * size / 20);
            for (int i = 0; i < nbTrees; i++)
            {
                var radiusForTree = Mathf.Sqrt(rand.Next(minsQ, sizeSq/4)+Mathf.Sqrt(rand.Next(min, sizeBiCub))/2);
                var angle = (float) rand.NextDouble()*360;
                var pos= new Vector3(radiusForTree*Mathf.Cos(angle),0, radiusForTree * Mathf.Sin(angle));
                SetATree(provider,pos,island,rand);
            }
        }

        public void SetATree(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var fP = provider;
            var tree = fP.IslandElementFactory.Create();
            tree.Factory = fP.IslandElementFactory;
            tree.IslandElementViewSettings = new IslandElementViewSettings() { IsTree = true,Seed= rand.Next(0,100) };
            tree.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            tree.HarvestController.harvestTactic = new TreeHarvestControllerTactic(tree);
            tree.SizeController = new TreeSizeController();
            var resourceCount = new Dictionary<ResourceType, int>();
            resourceCount[ResourceType.Wood] = 10;
            tree.HarvestInfo = new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false);
            island.ContainerControllerIsland.AddElement(tree);
            tree.RelativeToContainerPosition = relPosition;
        }
    }
}