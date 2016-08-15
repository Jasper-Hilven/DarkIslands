using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class UnitActionHandlerFactory
    {
        public HashSet<UnitActionHandler> toUpdate= new HashSet<UnitActionHandler>();

        public void Update()
        {
            var toUpClone = toUpdate.ToList();
            foreach (var unitActionHandler in toUpClone)
            {
                unitActionHandler.Update();
            }
        }
    }
}