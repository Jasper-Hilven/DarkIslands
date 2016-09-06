using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class IslandElementHydrationControllerFactory
    {
        public List<IslandElementHydrationController> Dehydrators= new List<IslandElementHydrationController>();

        public void Update(float deltaTime)
        {
            foreach (var dehydrator in Dehydrators.ToList())
            {
                dehydrator.Update(deltaTime);
            }
        }
    }
}