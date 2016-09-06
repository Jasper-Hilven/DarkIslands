using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class IslandMovementControllerFactory
    {
        public List<IslandMovementController> Active = new List<IslandMovementController>();

        public void Update(float deltaTime)
        {
            if (Active.Count == 0)
                return;
            var newActive = Active.ToList();
            foreach (var islandMovementController in newActive)
            {
                islandMovementController.Update(deltaTime);
            }
        }
    }
}