using System;
using UnityEngine;
namespace DarkIslands
{
    class InventoryView : MonoBehaviour
    {
        public UnityEngine.Object EventSystem { get; private set; }
       private IslandElement FocussedUnit;

        private bool inventoryBuild = false;
            
        public void FocusOnUnit(IslandElement u)
        {
            if (u == null)
                CloseInventoryView();
            else
                OpenInventoryView(u);
        }

        private void OpenInventoryView(IslandElement u)
        {
            if (u == this.FocussedUnit)
                return;
            if (!inventoryBuild)
                BuildInventory();
            CloseInventoryView(); //Close the previous and different one (can be null)
            this.FocussedUnit = u;
           
        }

        public void BuildInventory()
        {

            GameObject Canvas = null;
            GameObject inventory = new GameObject();
            inventory.name = "Inventories";
            Canvas = (GameObject)Instantiate(Resources.Load("Prefabs/Canvas - Inventory") as GameObject);
            Canvas.transform.SetParent(inventory.transform, true);
            GameObject panel = (GameObject)Instantiate(Resources.Load("Prefabs/Panel - Inventory") as GameObject);
            panel.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0, 0f);
            panel.transform.SetParent(Canvas.transform, true);
            GameObject draggingItem = (GameObject)Instantiate(Resources.Load("Prefabs/DraggingItem") as GameObject);
            draggingItem.transform.SetParent(Canvas.transform, true);
            Inventory inv = panel.AddComponent<Inventory>();
            inv.getPrefabs();
            inv.setAsMain();
            inv.updateSlotAmount(12, 1);
            inv.width = 12;
            inv.height = 1;
            inv.paddingTop = 5;
            inv.paddingBottom = 5;
            var slotSize = Screen.width / 50;
            inv.updateSlotSize(slotSize);
            inv.updateIconSize((slotSize > 2) ? (slotSize - 2) : 1);
            inv.updatePadding(Screen.width / 200, Screen.width / 200);
            inv.adjustInventorySize();
            inv.updateSlotSize();
            panel.transform.localPosition = new Vector3(0, -Screen.height / 2 + slotSize, 0);
            inventoryBuild = true;
            inv.addItemToInventory(4);
            inv.openInventory();
        }

        private void CloseInventoryView()
        {
            this.FocussedUnit = null;
          
        }

       
    }
}