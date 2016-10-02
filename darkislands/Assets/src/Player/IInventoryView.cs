namespace DarkIslands
{
    public interface IInventoryView
    {
        void FocusOn(IslandElement islandElement);
        void Update(float deltaTime);
        void SetDatabase(InventoryDatabase inventoryDatabase);
        void UpdateInventoryFromGameLogicToUnity();
    }
}