using System.Collections.Generic;
using Assets.src.World;
using UnityEngine;

namespace DarkIslands
{
    public class WorldBuilder
    {
        public UnitBuilder uBuilder { get; private set; }
        public BuildingBuilder bBuilder { get; private set; }

        public WorldBuilder(UnitBuilder uBuilder, BuildingBuilder bBuilder)
        {
            this.uBuilder = uBuilder;
            this.bBuilder = bBuilder;
        }
        public void BuildWorld(FactoryProvider provider)
        {
            BuildIsland(provider, new Vector3(200, 0, 0), 100f, 2);
            BuildIsland(provider, new Vector3(0, 0, 0), 30f, 2);
        }

        public Island BuildIsland(FactoryProvider provider, Vector3 Position, float size, int seed)
        {
            var island = provider.IslandFactory.Create();
            island.SizeController.SetInitialSize(size);
            island.Position = Position;
            island.WorldBuilder = this;
            SetTreesAndRocks(provider, island, new System.Random(seed));
            return island;

        }


        public void SetTreesAndRocks(FactoryProvider provider, Island island, System.Random rand)
        {
            var size = Mathf.RoundToInt(island.Size);
            if (size < 5)
                return;
            var sizeSq = (size - 1) * (size - 1);
            var minsQ = 4 * 4;
            var sizeBiCub = (size - 1) * (size - 1) * size * size;
            var nbTrees = (size * size / 10 + rand.Next(0, size * size / 20)) / 4;
            for (int i = 0; i < nbTrees; i++)
            {
                var radiusForTree = Mathf.Sqrt(rand.Next(minsQ, sizeSq));
                var angle = (float)rand.NextDouble() * 360;
                var pos = new Vector3(radiusForTree * Mathf.Cos(angle), 0, radiusForTree * Mathf.Sin(angle));
                SetANatureElement(provider, pos, island, rand);
            }
        }

        public void SetATree(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var tree = GetBasicResource(provider, relPosition, island, rand);
            tree.IslandElementViewSettings = new IslandElementViewSettings() { IsTree = true, Seed = rand.Next(0, 100), HasLifeStatVisualization = false };
            var resourceCount = new Dictionary<ResourceType, int> { };
            resourceCount[ResourceType.Wood] = 5;
            tree.HarvestController.SetHarvestSettings(
                new SimpleHarvestedControllerTactic(tree, resourceType: ResourceType.Wood), new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false));
            tree.SizeController = new ResourceAmountSizeController(ResourceType.Wood);
        }

        public void SetANatureElement(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var selected = rand.Next(3);
            if (selected == 0)
                SetARock(provider, relPosition, island, rand);
            if (selected == 1)
                SetATree(provider, relPosition, island, rand);
            if (selected == 2)
                SetGrass(provider, relPosition, island, rand);


        }

        public IslandElement GetBasicResource(FactoryProvider provider, Vector3 relPosition, Island island,
            System.Random rand)
        {
            var fP = provider;
            var resource = fP.IslandElementFactory.Create();
            resource.Factory = fP.IslandElementFactory;
            resource.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            island.ContainerControllerIsland.AddElement(resource);
            resource.RelativeToContainerPosition = relPosition;
            return resource;

        }
        public void SetARock(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var rock = GetBasicResource(provider, relPosition, island, rand);
            rock.SizeController = new ResourceAmountSizeController(ResourceType.Stone);
            rock.HarvestController.harvestTactic = new SimpleHarvestedControllerTactic(rock, resourceType: ResourceType.Stone);
            var resourceCount = new Dictionary<ResourceType, int>();
            bool isBig = rand.Next(0, 2) > 0;
            rock.IslandElementViewSettings = new IslandElementViewSettings() { IsRock = true, RockInfo = new RockInfo { Big = true }, Seed = rand.Next(0, 100), HasLifeStatVisualization = false };
            resourceCount[ResourceType.Stone] = isBig ? 2 : 1;
            rock.HarvestInfo = new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false);
        }

        public void SetGrass(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var grass = GetBasicResource(provider, relPosition, island, rand);
            grass.HarvestController.SetHarvestSettings(null, new HarvestInfo(false, false, null, null, false, false, false));
            grass.IslandElementViewSettings = new IslandElementViewSettings() { IsGrass = true };
            grass.CircleElementProperties = new CircleElementProperties(0, 0);
        }

    }
}