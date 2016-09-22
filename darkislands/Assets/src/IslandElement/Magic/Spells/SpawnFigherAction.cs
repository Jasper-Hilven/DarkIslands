using UnityEngine;

namespace DarkIslands
{
    public class SpawnFigherAction : IIslandElementAction
    {
        public SpawnFigherAction(bool isArcher)
        {
            this.isArcher = isArcher;
        }
        private float totalActionTime = 0f;
        private bool isArcher;

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!islandElement.CanUseMana)
                return true;
            var island = islandElement.Island;
            if (island == null)
                return true;
            totalActionTime += deltaTime;
            if (totalActionTime < 1f)
                return false;
            islandElement.MagicController.RemoveMana(10);
            var team = islandElement.TeamController.Team;
            var unitBuilder = island.WorldBuilder.uBuilder;
            var relativeToContainerPosition = islandElement.RelativeToContainerPosition + new Vector3(0.8f,0, 0.8f);
            var fighter = unitBuilder.GetSpawnedFighter(islandElement, island, relativeToContainerPosition, team,isArcher);
            fighter.ActionHandler.SetNextCommand(new FollowAndProtectCommand(islandElement));
            fighter.SpawnController.SetSpawn(60);
            return true;
        }

    }
}