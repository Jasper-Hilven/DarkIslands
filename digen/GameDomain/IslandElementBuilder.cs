using System.Collections.Generic;

namespace DarkIslandGen
{
    public class IslandElementBuilder
    {
        public static List<ModelClass> GetIslandElementParts(Property position, Property circleProps, TVariable modelToEntity)
        {
            var properties = new List<Property>();
            var parts = new List<ModelClass>();
            var islandElement = new ModelClass
            {
                Name = "IslandElement"
            };
            var islandElementParts = new List<ModelClass> { islandElement };


            //Factory
            properties.Add(new Property("Factory", "IslandElementFactory"));

            //Inventory
            properties.Add(new Property("Inventory", "Inventory"));
            properties.Add(new Property("HasInventory", "bool"));
            properties.Add(new Property("InventoryController", "InventoryController"));
            islandElementParts.Add(new ModelClass { Name = "InventoryController", ParentRelation = islandElement });

            //PositionInfo
            var islandPosition = new Property("IslandPosition", "Vector3");
            properties.Add(islandPosition);
            var relativeToContainerPosition = new Property("RelativeToContainerPosition", "Vector3");
            properties.Add(relativeToContainerPosition);
            properties.Add(position);

            //Island
            var island = new Property("Island", new GType { name = "Island" });
            properties.Add(island);
            var islandToEnter = new Property("IslandToEnter", new GType { name = "Island" });
            properties.Add(islandToEnter);
            properties.Add(circleProps);
            properties.Add(new Property("IslandManager", "IslandElementContainerManager"));
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementContainerManager",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { islandToEnter, islandPosition, relativeToContainerPosition }
            });

            //NearOthersController
            properties.Add(new Property("NearOthersController", "NearOthersController"));
            islandElementParts.Add(new ModelClass
            {
                Name = "NearOthersController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { relativeToContainerPosition }
            });

            //Movement
            properties.Add(new Property("MaxSpeed", new GType { name = "float" }));
            properties.Add(new Property("MovementController", "IslandElementMovementController"));
            var relGoalPosition = new Property("RelativeGoalPosition", new GType { name = "Vector3", dep = "UnityEngine" });
            properties.Add(relGoalPosition);
            var hasRelGoalPosition = new Property("HasRelativeGoalPosition", "bool");
            properties.Add(hasRelGoalPosition);
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementMovementController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { relativeToContainerPosition, relGoalPosition, hasRelGoalPosition, islandPosition, island }
            });

            //Actions
            var curCommand = new Property("CurrentCommand", "IIslandElementCommand");
            properties.Add(curCommand);
            var curAction = new Property("CurrentAction", "IIslandElementAction");
            properties.Add(curAction);
            var curlifeAction = new Property("CurrentLifeAction", "IIslandElementAction");
            properties.Add(curlifeAction);
            properties.Add(new Property("ActionHandler", "IslandElementActionHandler"));
            islandElementParts.Add(new ModelClass { Name = "IslandElementActionHandler", ParentRelation = islandElement, UseFromParent = new List<Property> { curCommand, curAction, curlifeAction } });

            //Light
            var hasLight = new Property("hasLight", "bool");
            properties.Add(hasLight);
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementLightController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { hasLight, position }
            });

            //Resources
            var harvestController = new Property("HarvestController", "HarvestController");
            properties.Add(harvestController);
            islandElementParts.Add(new ModelClass
            {
                Name = "HarvestController",
                ParentRelation = islandElement
                ,
                UseFromParent = new List<Property> { harvestController }
            });
            var harvestInfo = new Property("HarvestInfo", "HarvestInfo");
            properties.Add(harvestInfo);

            //SizeInfo
            var size = new Property("Size", "float");
            var SizeController = new Property("SizeController", "ISizeController");
            properties.Add(size);
            properties.Add(SizeController);
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementSizeController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { harvestInfo, SizeController }
            });

            //Collision
            islandElementParts.Add(new ModelClass { Name = "CollisionSizeManager", ParentRelation = islandElement, UseFromParent = new List<Property> { size } });


            //DropOffController
            var islandDropOffController = new Property("DropOffController", "IslandElementDropOffController");
            properties.Add(islandDropOffController);
            islandElementParts.Add(new ModelClass { Name = "IslandElementDropOffController", ParentRelation = islandElement, UseFromParent = new List<Property>() { relativeToContainerPosition } });



            //Elementalz

            var isElementalColored = new Property("IsElementalColored", "bool");
            properties.Add(isElementalColored);
            var hasElementalView = new Property("hasElementalView", "bool");
            properties.Add(hasElementalView);
            var elementalInfo = new Property("ElementalInfo", "ElementalInfo");
            properties.Add(elementalInfo);
            var elementalType = new Property("ElementalType", new GType { name = "IElementalType" });
            properties.Add(elementalType);

            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementElementalController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { }
            });
            properties.Add(new Property("ElementalController", "IslandElementElementalController"));
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementElementalView",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { isElementalColored, hasElementalView, elementalInfo, elementalType }
            });

            //Magic
            var manaPoints = new Property("ManaPoints", "int");
            properties.Add(manaPoints);
            var maxManaPoints = new Property("MaxManaPoints", "int");
            properties.Add(maxManaPoints);
            properties.Add(new Property("CanUseMana", "bool"));
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementMagicController",
                ParentRelation = islandElement,
                UseFromParent = new List<Property> { }
            });
            properties.Add(new Property("MagicController", "IslandElementMagicController"));

            //Hydration
            var candehydrate = new Property("CanDehydrate", "bool");
            properties.Add(candehydrate);
            var hydrationPoints = new Property("HydrationPoints", "int");
            properties.Add(hydrationPoints);
            var maxHydrationPoints = new Property("MaxHydrationPoints", "int");
            properties.Add(maxHydrationPoints);
            properties.Add(new Property("DehydrationRate", "int"));
            properties.Add(new Property("HydrationController", "IslandElementHydrationController"));
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementHydrationController",
                ParentRelation = islandElement
            ,
                UseFromParent = new List<Property> { candehydrate }
            });


            //LifePoints
            var lifePoints = new Property("LifePoints", "int");
            properties.Add(lifePoints);
            var lifeController = new Property("LifeController", "IslandElementLifeController");
            properties.Add(lifeController);
            var maxLifePoints = new Property("MaxLifePoints", "int");
            properties.Add(maxLifePoints);
            properties.Add(new Property("IsAlive", new GType { name = "bool" }));
            islandElementParts.Add(new ModelClass { Name = "IslandElementLifeController", ParentRelation = islandElement });

            //Spawning
            properties.Add(new Property("IsSpawned", "bool"));
            properties.Add(new Property("SpawnParent", "IslandElement"));
            properties.Add(new Property("SpawnTimeToLife", "float"));
            properties.Add(new Property("SpawnController", "IslandElementSpawnController"));
            islandElementParts.Add(new ModelClass() { Name = "IslandElementSpawnController", ParentRelation = islandElement });

            //BaseVisualization
            var viewSettings = new Property("IslandElementViewSettings", "IslandElementViewSettings");
            properties.Add(viewSettings);
            islandElementParts.Add(new ModelClass
            {
                Name = "IslandElementUnityView",
                ParentRelation = islandElement,
                ConstructionInjected = new List<TVariable> { modelToEntity },
                UseFromParent = new List<Property> { viewSettings, isElementalColored, elementalType, position, size }
            });

            //AnimationVisualization
            islandElementParts.Add(new ModelClass { Name = "IslandElementUnityAnimationController", ParentRelation = islandElement, ConstructionInjected = new List<TVariable> { modelToEntity } });
            properties.Add(new Property("IsAnimated", "bool"));

            //HoverVisualization
            islandElementParts.Add(new ModelClass { Name = "IslandElementHoverController", ParentRelation = islandElement });
            properties.Add(new Property("GivesHoverInformation", "bool"));

            //SelectController
            islandElementParts.Add(new ModelClass { Name = "IslandSelectionController", ParentRelation = islandElement });
            properties.Add(new Property("CanBeSelected", "bool"));

            //Stats visualization
            islandElementParts.Add(new ModelClass("IslandElementUnityStatsView", islandElement)
            {
                UseFromParent = new List<Property>
                {
                position,lifePoints,maxLifePoints,hydrationPoints,maxHydrationPoints,manaPoints,maxManaPoints,viewSettings
            }
            });

            //FightingController
            properties.Add(new Property("FightingController", "IslandElementFightingController"));
            islandElementParts.Add(new ModelClass("IslandElementFightingController", islandElement));

            //TeamController
            properties.Add(new Property("TeamController", "IslandElementTeamController"));
            islandElementParts.Add(new ModelClass("IslandElementTeamController", islandElement));

            islandElement.properties = properties;
            islandElementParts.AddRange(parts);
            return islandElementParts;
        }
    }
}