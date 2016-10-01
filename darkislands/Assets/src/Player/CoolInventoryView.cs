using DarkIslands;
using DarkIslands.Player;
using UnityEngine;

namespace DarkIslands
{
    public class CoolInventoryView : IInventoryView
    {
        private GameObjectManager gameObjectManager;
        private GameObject view;
        private IslandElement focussedOn;
        private FollowCamera camera;
        private ModelToEntity mToEInventory;
        private InventoryDatabase inventoryDatabase;

        public CoolInventoryView(GameObjectManager gameObjectManager,FollowCamera camera, ModelToEntity mToEInventory)
        {
            this.gameObjectManager = gameObjectManager;
            this.camera = camera;
            this.mToEInventory= mToEInventory;
        }

        public void Update(float deltaTime)
        {
            if (focussedOn != null && view != null)
                view.transform.position = (camera.GetPosition()) + new Vector3(0,-4,1.4f);
        }

        public void SetDatabase(InventoryDatabase inventoryDatabase)
        {
            this.inventoryDatabase = inventoryDatabase;
        }

        public void UpdateInventoryFromGameLogicToUnity()
        {
            updateContainingInventory();
        }

        private void updateContainingInventory()
        {
            if (focussedOn == null)
                return;
            var inventory= focussedOn.InventoryController.Inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                var inventoryItem = inventory[i];
                GameObject itemView = inventoryItem.InventoryType.GetViewObject();

            }
            foreach (var inventoryItem in inventory)
            {
            }
        }
        public void FocusOn(IslandElement islandElement)
        {
            if (islandElement == focussedOn)
                return;
                DestroyView();
            CreateViewForIslandElement(islandElement);
            focussedOn = islandElement;

        }

        private void DestroyView()
        {
            if (view == null)
                return;
            gameObjectManager.DestroyObj(view);
            view = null;
        }

        public void CreateViewForIslandElement(IslandElement element)
        {
            if (element == null)
                return;
            view = gameObjectManager.LoadViaResources("Inventory");
            updateContainingInventory();
        }


        public void InitializeAfterScreenLoaded()
        {

        }
    }
}