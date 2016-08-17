using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class ShipMovementControllerFactory
    {
         public HashSet<ShipMovementController> UpdateShips = new HashSet<ShipMovementController>();

        public void Update(float deltaTime)
        {
            var c = UpdateShips.ToList();
            foreach (var shipMovementController in c)
            {
                shipMovementController.Update(deltaTime);
            }
        }
    }
}