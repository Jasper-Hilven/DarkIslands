namespace DarkIslands
{
    public class HarvestIslandManaAction: IIslandElementAction
    {
        public HarvestIslandManaAction(int magmaLevel)
        {
            this.magmaLevel = magmaLevel;
        }
        private float totalActionTime = 0;
        private int magmaLevel;

        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!islandElement.CanUseMana)
                return true;
            if (islandElement.Island == null)
                return true;
            if (!islandElement.Island.SizeController.CanRemoveByMagic())
                return true;
            totalActionTime += deltaTime;
            if (totalActionTime < 1f)
                return false;
            islandElement.Island.SizeController.RemoveByMagic((1 + magmaLevel));
            islandElement.MagicController.AddMana(1);
            return true;
        }
    }
}