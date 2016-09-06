using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class IslandElementActionHandlerFactory
    {
        public HashSet<IslandElementActionHandler> toUpdate= new HashSet<IslandElementActionHandler>();

        public void Update(float deltaTime)
        {
            var toUpClone = toUpdate.ToList();
            foreach (var unitActionHandler in toUpClone)
            {
                unitActionHandler.Update(deltaTime);
            }
        }
    }
}