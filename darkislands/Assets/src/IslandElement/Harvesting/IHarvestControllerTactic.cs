namespace DarkIslands
{
    public interface IHarvestControllerTactic
    {
        void Harvest(float harvestEffort, IslandElement harvested);
        ResourceAmount GetHarvested(float harvestEffort);
    }
}