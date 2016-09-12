using System;
using System.Collections.Generic;
using UnityEngine;
namespace DarkIslands
{
    public class InventoryViewFacade 
    {
        public UnityEngine.Object EventSystem { get; private set; }
        private IslandElement FocussedUnit;
        private Inventory unityInventory;
        private bool inventoryBuild = false;
        private DIInventoryDatabase database;
        private GameObjectManager gObjManager;

        public InventoryViewFacade(GameObjectManager gObjManager)
        {
            this.gObjManager = gObjManager;
        }
        public void SetDatabase(DIInventoryDatabase database)
        {
            this.database = database;
        }


        private void OpenInventoryView()
        {
            if (!screenLoaded)
                return;
            if (!inventoryBuild)
                BuildInventory();
            UpdateInventoryFromGameLogicToUnity();
        }

        private bool screenLoaded = false;

        public void InitializeAfterScreenLoaded()
        {
            screenLoaded = true;
            if (this.FocussedUnit != null)
                BuildInventory();
            UpdateInventoryFromGameLogicToUnity();
        }

        private void BuildInventory()
        {
            GameObject Canvas = null;
            GameObject inventory = new GameObject();
            inventory.name = "Inventories";
            Canvas = (GameObject)gObjManager.LoadViaResources("Prefabs/Canvas - Inventory");
            Canvas.transform.SetParent(inventory.transform, true);
            GameObject panel = (GameObject)gObjManager.LoadViaResources("Prefabs/Panel - Inventory");
            panel.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0, 0f);
            panel.transform.SetParent(Canvas.transform, true);
            GameObject draggingItem = (GameObject)gObjManager.LoadViaResources("Prefabs/DraggingItem");
            draggingItem.transform.SetParent(Canvas.transform, true);
            Inventory inv = panel.AddComponent<Inventory>();
            inv.width = 12;
            inv.height = 1;
            inv.paddingTop = 5;
            inv.paddingBottom = 5;
            inv.paddingLeft = 5;
            inv.paddingRight = 5;
            var slotSize = Screen.width / 20;
            var iconSize = (slotSize > 2) ? (slotSize - 2) : 1;
            inv.slotSize = slotSize;
            inv.iconSize = iconSize;
            inv.positionNumberX = slotSize / 3;
            inv.positionNumberY = slotSize / 3;
            inv.SetDatabase(database);
            inv.getPrefabs();
            inv.setAsMain();
            inv.updateSlotAmount(12, 1);
            inv.updateSlotSize(slotSize);
            inv.updateIconSize(iconSize);
            inv.updatePadding(Screen.width / 200, Screen.width / 200);
            inv.adjustInventorySize();
            panel.transform.localPosition = new Vector3(0, -Screen.height / 2 + slotSize/2, 0);
            inv.openInventory();
            //inv.updateSlotSize(slotSize);
            inv.updateIconSize((slotSize > 2) ? (slotSize - 2) : 1);
            inv.updatePadding(Screen.width / 200, Screen.width / 200);
            inv.adjustInventorySize();
            inv.stackable = true;
            inventoryBuild = true;
            inv.addAllItemsToInventory();
            this.unityInventory = inv;
            inv.gameView = this;
            inv.EItemListChanged += UpdateInventoryFromUnity;
        }

        
        public void UpdateInventoryFromGameLogicToUnity()
        {
            var Inventory = this.FocussedUnit.InventoryController.Inventory;
            if (unityInventory == null)
                return;
            unityInventory.SetNewItemsList(GameToUnity(Inventory));
        }
        #region FromUnityToGame

        private void UpdateInventoryFromUnity()
        {
            if (FocussedUnit == null)
                return;
            FocussedUnit.InventoryController.ReceiveView(UnityToGame(unityInventory.ItemsInInventory));
        }

        public void ConsumeItemAt(int index)
        {
            var myItem = this.FocussedUnit.InventoryController.Inventory[index];
            this.FocussedUnit.InventoryController.ConsumeItem(myItem);
        }
        private List<InventoryItem> UnityToGame(List<Item> items)
        {
            var ret = new List<InventoryItem>();
            foreach (var item in items)
            {
                ret.Add(database.ToInventoryItem(item));
            }
            return ret;
        }
        #endregion

        public void FocusOn(IslandElement element)
        {
            if (element == null)
            {
                if (FocussedUnit == null)
                    return;
                this.FocussedUnit.InventoryController.SetActiveToInventoryView(null);
                this.FocussedUnit = null;
                return;
            }
            if (this.FocussedUnit != null)
            {
                this.FocussedUnit.InventoryController.SetActiveToInventoryView(null);
                this.FocussedUnit = null;
            }
            this.FocussedUnit = element;
            this.FocussedUnit.InventoryController.SetActiveToInventoryView(this);
            OpenInventoryView();


        }

        private List<Item> GameToUnity(List<InventoryItem> items)
        {
            var ret = new List<Item>();
            foreach (var item in items)
            {
                ret.Add(DIInventoryDatabase.FromInventoryItem(item));
            }
            return ret;
        }
     

    }
}