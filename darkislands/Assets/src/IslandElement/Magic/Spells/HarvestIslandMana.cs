namespace DarkIslands
{
    public class HarvestIslandMana:ISpell
    {
        public bool CanSee(IslandElement elem)
        {
            return true;
        }

        public bool CanDo(IslandElement elem)
        {
            if (elem.Island == null)
                return false;
            return elem.CanUseMana;
        }

        public IIslandElementAction Do(IslandElement elem)
        {
            return new HarvestIslandManaAction(elem.ElementalInfo.MagmaLevel);
        }
    }
}