using System.Collections.Generic;

namespace DarkIslands
{
    public class HarvestIslandManaAction : IIslandElementAction
    {
        public HarvestIslandManaAction(int magmaLevel, bool harvest = true)
        {
            this.harvest = harvest;
            this.magmaLevel = magmaLevel;
        }
        private float totalActionTime = 0;
        private int magmaLevel;
        private bool harvest;
        private const int costMana = 1;
        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (!harvest && islandElement.ManaPoints < costMana)
                return true;
            if (!islandElement.CanUseMana)
                return true;
            if (islandElement.Island == null)
                return true;
            if (!islandElement.Island.SizeController.CanRemoveByMagic())
                return true;
            totalActionTime += deltaTime;
            if (totalActionTime < 1f)
                return false;
            if (harvest)
            {
                islandElement.Island.SizeController.RemoveByMagic((1 + magmaLevel));
                islandElement.MagicController.AddMana(1);
                return true;
            }
            islandElement.Island.SizeController.GiveByMagic(1 + magmaLevel);
            islandElement.MagicController.RemoveMana(1);
            return true;
        }
    }
}