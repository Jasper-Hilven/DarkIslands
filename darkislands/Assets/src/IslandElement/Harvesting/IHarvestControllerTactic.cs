namespace DarkIslands
{
    public interface IHarvestControllerTactic
    {
        void Harvest(float harvestEffort, IslandElement harvested);
        InventoryAmount GetHarvested(float harvestEffort);
    }
}