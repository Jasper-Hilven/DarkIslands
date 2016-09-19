using System.Linq;
using Boo.Lang;

namespace DarkIslands
{
    public partial class IslandElementSpawnControllerFactory
    {
        public List<IslandElementSpawnController> active= new List<IslandElementSpawnController>(); 
        public void Update(float deltaTime)
        {
            if (active.Count == 0)
                return;
            foreach (var islandElementSpawnController in active.ToList())
                islandElementSpawnController.Update(deltaTime);

        }
    }
}