namespace DarkIslands
{
    public class SpellCommand: IIslandElementCommand
    {
        private ISpell spell;

        public SpellCommand(ISpell spell)
        {
            this.spell = spell;
        }
        public IIslandElementAction GetAction()
        {
            return new DoSpellAction(spell);
        }
    }
}