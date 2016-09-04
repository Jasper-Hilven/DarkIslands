using UnityEngine;

namespace DarkIslands
{
    public class DropOffAction:IIslandElementAction
    {
        private float fallSpeed = 0f;
        public bool Update(IslandElement islandElement, float deltaTime)
        {

            islandElement.IslandManager.EnterIsland(null);
            fallSpeed += deltaTime*10f;
            var fallDistance = fallSpeed * deltaTime;
            islandElement.Position += new Vector3(0,-fallDistance,0);
            if (!(islandElement.Position.y < -400f)) return false;
            islandElement.LifeController.DieDueToFalling();
            return true;
        }
    }
}