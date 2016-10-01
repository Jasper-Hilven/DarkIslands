using System.Collections.Generic;
using Assets.src.World;
using UnityEngine;

namespace DarkIslands
{
    public class WorldBuilder
    {
        private UnityViewFactory viewFac;
        private InventoryDatabase inventoryDatabase;

        public UnitBuilder uBuilder { get; private set; }
        public BuildingBuilder bBuilder { get; private set; }

        public WorldBuilder(UnitBuilder uBuilder, BuildingBuilder bBuilder, UnityViewFactory viewFac, InventoryDatabase inventoryDatabase)
        {
            this.uBuilder = uBuilder;

            this.bBuilder = bBuilder;
            this.viewFac = viewFac;
            this.inventoryDatabase = inventoryDatabase;
        }
        public void BuildWorld(FactoryProvider provider)
        {
            BuildIsland(provider, new Vector3(0, 0, 0), 30f, 2);
            BuildIsland(provider, new Vector3(200, 0, 0), 100f, 2);
        }

        public Island BuildIsland(FactoryProvider provider, Vector3 Position, float size, int seed)
        {
            var island = provider.IslandFactory.Create();
            island.SizeController.SetInitialSize(size);
            island.Position = Position;
            island.WorldBuilder = this;
            SetNatureElements(provider, island, new System.Random(seed));
            return island;

        }


        public void SetNatureElements(FactoryProvider provider, Island island, System.Random rand)
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
            tree.IslandElementViewSettings = new IslandElementViewSettings() {  GetGameObject= () => viewFac.GetTreeVisualization(rand.Next(0, 100)),HasLifeStatVisualization = false };
            var resourceCount = new Dictionary<InventoryType, int> { };
            resourceCount[inventoryDatabase.Wood] = 5;
            tree.HarvestController.SetHarvestSettings(
                new SimpleHarvestedControllerTactic(tree, InventoryType: inventoryDatabase.Wood), new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false,false));
            tree.SizeController = new ResourceAmountSizeController(inventoryDatabase.Wood);
        }

        public void SetANatureElement(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var selected = rand.Next(8);
            if (selected == 0)
                SetARock(provider, relPosition, island, rand);
            if (selected == 1)
                SetATree(provider, relPosition, island, rand);
            if (selected == 2)
                SetAMushroom(provider, relPosition, island, rand);
            if (selected > 2 && selected < 8)
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
            resource.Size = 1;
            return resource;

        }
        public void SetARock(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var rock = GetBasicResource(provider, relPosition, island, rand);
            rock.SizeController = new ResourceAmountSizeController(inventoryDatabase.Stone);
            rock.HarvestController.harvestTactic = new SimpleHarvestedControllerTactic(rock, InventoryType: inventoryDatabase.Stone);
            var resourceCount = new Dictionary<InventoryType, int>();
            var isBig = rand.Next(0, 2) > 0;
            rock.IslandElementViewSettings = new IslandElementViewSettings() { GetGameObject=()=> viewFac.GetRockVisualization(isBig,rand.Next()), HasLifeStatVisualization = false };
            resourceCount[inventoryDatabase.Stone] = isBig ? 2 : 1;
            rock.HarvestInfo = new HarvestInfo(true, false, resourceCount, resourceCount, false, false, false,false);
        }

        public void SetAMushroom(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var mushroom = GetBasicResource(provider, relPosition, island, rand);
            mushroom.HarvestController.harvestTactic = new SimpleHarvestedControllerTactic(mushroom, InventoryType: inventoryDatabase.BrownMushroom);
            var resourceCount = new Dictionary<InventoryType, int>();
            mushroom.IslandElementViewSettings = new IslandElementViewSettings() { GetGameObject=()=>viewFac.GetBrownMushroomVisualization( rand.Next()), HasLifeStatVisualization = false };
            resourceCount[inventoryDatabase.BrownMushroom] = 1;
            mushroom.HarvestInfo = new HarvestInfo(false, false, resourceCount, resourceCount, false, false, true,false);
            mushroom.CircleElementProperties.OriginalRadius = 0.2f;
            mushroom.Size = 1f;
        }

        public void SetGrass(FactoryProvider provider, Vector3 relPosition, Island island, System.Random rand)
        {
            var grass = GetBasicResource(provider, relPosition, island, rand);
            grass.IslandElementViewSettings = new IslandElementViewSettings() { GetGameObject = () => viewFac.GetGrassVisualization( rand.Next()) };
            grass.CircleElementProperties = new CircleElementProperties(0.5f, 0.5f);
            grass.HarvestController.harvestTactic = new SimpleHarvestedControllerTactic(grass, InventoryType: inventoryDatabase.Grass);
            var resourceCount = new Dictionary<InventoryType, int>();
            resourceCount[inventoryDatabase.Grass] = 1;
            grass.HarvestInfo = new HarvestInfo(false, false, resourceCount, resourceCount, false, false, true, false);
            grass.Size = 1;
        }

    }
}