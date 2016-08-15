using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class UnitMovementControllerFactory
    {
        public HashSet<UnitMovementController> MovingElements= new HashSet<UnitMovementController>();
        public void Update(float deltaTime)
        {
            if (MovingElements.Count == 0)
                return;
            var movingElemClone = MovingElements.ToList();
            foreach (var movingElement in movingElemClone)
                movingElement.Update(deltaTime);
        }
    }
}