using System;
using System.Collections.Generic;

namespace DarkIslands
{
    public partial class IWOContainerControllerIsland : IWOContainerController
    {
        public override void Init(Island Island, IWOContainerControllerIslandFactory IWOContainerControllerIslandFactory)
        {
            this.Island = Island;
            Island.WOContainerController = this;
        }

        public Island Island { get; set; }
        private List<WorldObject> worldObjects = new List<WorldObject>();
        public override void PositionChanged()
        {
            updateWOPositions();
        }

        private void updateWOPositions()
        {
            foreach (var worldObject in worldObjects)
            {
                worldObject.ContainerPosition = Island.Position;
            }
        }

        public bool CanAddWO(WorldObject wo)
        {
            return wo.Container == null;
        }

        public void AddWO(WorldObject wo)
        {
            if (!CanAddWO(wo))
            {
                Console.WriteLine("Cannot add WO");
                return;
            }
            wo.Container = this.Island;
            worldObjects.Add(wo);
            
        }

        public void RemoveWO(WorldObject wo)
        {
            wo.Container = null;
            worldObjects.Remove(wo);
        }

        public List<WorldObject> GetContainingUnits { get { return worldObjects; } }
    }
}