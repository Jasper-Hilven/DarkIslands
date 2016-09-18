namespace DarkIslands
{
    public class DoSpellAction:IIslandElementAction
    {
        private IIslandElementAction decoAction;
        private ISpell spell;

        public DoSpellAction(ISpell spell)
        {
            this.spell = spell;
        }
        public bool Update(IslandElement islandElement, float deltaTime)
        {
            if (decoAction == null)
                decoAction = spell.Do(islandElement);
            return decoAction.Update(islandElement, deltaTime);
        }
    }
}