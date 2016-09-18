namespace DarkIslands
{
    public class SpawnTowerAction : IIslandElementAction
    {
        private float totalActionTime = 0f;

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!islandElement.CanUseMana)
                return true;
            if (islandElement.Island == null)
                return true;
            totalActionTime += deltaTime;
            if (totalActionTime < 1f)
                return false;

            islandElement.MagicController.AddMana(1);
            return true;

        }

    }
}