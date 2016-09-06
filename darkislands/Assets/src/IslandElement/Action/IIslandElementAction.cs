namespace DarkIslands
{
    public interface IIslandElementAction
    {
        bool Update(IslandElement islandElement, float deltaTime);
    }
}