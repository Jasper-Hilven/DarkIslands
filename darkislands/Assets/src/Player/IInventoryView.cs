namespace DarkIslands
{
    public interface IInventoryView
    {
        void FocusOn(IslandElement islandElement);
        void Update(float deltaTime);
        void InitializeAfterScreenLoaded();
        void SetDatabase(DIInventoryDatabase inventoryDatabase);
        void UpdateInventoryFromGameLogicToUnity();
    }
}