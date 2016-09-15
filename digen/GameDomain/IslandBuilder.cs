using System.Collections.Generic;

namespace DarkIslandGen
{
    public class IslandBuilder
    {
        public static List<ModelClass> GetIslandParts(Property position, Property circleProps, TVariable modelToEntity)
        {
            var properties = new List<Property>();
            var island= new ModelClass{Name = "Island"};
            var islandParts = new List<ModelClass> { island};

            //Size
            var size = new Property("Size", "float");
            var mass = new Property("Mass", "float");
            properties.Add(size);
            properties.Add(mass);
            islandParts.Add(new ModelClass { Name = "IslandSizeController", ParentRelation = island });
            var sizeController = new Property("SizeController", "IslandSizeController");
            properties.Add(sizeController);

            //Movement
            properties.Add(position);
            var speed = new Property("Speed","Vector3");
            properties.Add(new Property("MovementController", "IslandMovementController"));
            properties.Add(speed);
            islandParts.Add(new ModelClass {Name = "IslandMovementController", ParentRelation = island, UseFromParent = new List<Property> {speed } });

            //Container
            var containercontrollerisland = new Property("ContainerControllerIsland", "ContainerControllerIsland");
            properties.Add(containercontrollerisland);
            islandParts.Add(new ModelClass{Name = "ContainerControllerIsland",ParentRelation = island,
                UseFromParent = new List<Property> {containercontrollerisland,position} });

            //Collision

            properties.Add(new Property("IslandCollision", "OnIslandCollision")); //Elements
            properties.Add(circleProps);
            islandParts.Add(new ModelClass {Name = "OnIslandCollision",ParentRelation = island});
            islandParts.Add(new ModelClass
            {Name = "InterIslandCollision",ParentRelation = island,
                UseFromParent = new List<Property> {position} });
            islandParts.Add(new ModelClass { Name = "IslandCollisionSizeManager", ParentRelation = island, UseFromParent = new List<Property> { size } });

            //View
            islandParts.Add(new ModelClass
            {Name = "IslandUnityView",ParentRelation = island,
                ConstructionInjected = new List<TVariable>{modelToEntity},
                UseFromParent = new List<Property> {size,position} });

            //Mana
            var islandManaController = new ModelClass {Name = "IslandManaController",ParentRelation = island};
            islandParts.Add(islandManaController);

            island.properties = properties;
            return islandParts;
        }
    }
}