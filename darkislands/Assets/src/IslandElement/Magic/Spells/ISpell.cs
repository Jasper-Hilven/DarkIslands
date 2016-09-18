namespace DarkIslands
{
    public interface ISpell
    {
        bool CanSee(IslandElement elem);
        bool CanDo(IslandElement elem);
        IIslandElementAction Do(IslandElement elem);
    }
}