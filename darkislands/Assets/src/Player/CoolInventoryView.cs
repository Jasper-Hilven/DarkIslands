﻿using System.Collections.Generic;
using System.Linq;
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
        private List<InventoryItem> currentInventoryItems;
        private List<GameObject> inventoryItemViews;

        public CoolInventoryView(GameObjectManager gameObjectManager, FollowCamera camera, ModelToEntity mToEInventory)
        {
            this.gameObjectManager = gameObjectManager;
            this.camera = camera;
            this.mToEInventory = mToEInventory;
        }

        public void Update(float deltaTime)
        {
            if (focussedOn != null && view != null)
            {
                view.transform.position = (camera.GetPosition()) + new Vector3(0, -6, 2.1f);
                UpdateViewItemsLocation();
                if (Input.GetKeyDown(KeyCode.Mouse1))
                    UseItemIfClicked();
            }
            
        }

        public void UpdateViewItemsLocation()
        {
            var basePos = view.transform.position;
            if (inventoryItemViews == null)
                return;
            for (int i = 0; i < inventoryItemViews.Count; i++)
            {
                var item = inventoryItemViews[i];
                if (item == null)
                    continue;
                item.transform.position = basePos + new Vector3(((float) i)/2 - 3, 0, 0);
            }
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
            var inventory = focussedOn.InventoryController.Inventory;
            for (int i = 0; i < inventory.Count; i++)
                SetItemAt(i, inventory[i]);
        }

        private void SetItemAt(int index, InventoryItem inventoryItem)
        {
            inventoryItemViews = inventoryItemViews ?? new List<GameObject>();
            currentInventoryItems = currentInventoryItems ?? new List<InventoryItem>();
            while (inventoryItemViews.Count <= index)
                inventoryItemViews.Add(null);
            while (currentInventoryItems.Count <= index)
                currentInventoryItems.Add(null);
            var previousItem = currentInventoryItems[index];
            if (previousItem == inventoryItem ||
                (previousItem != null && inventoryItem != null &&
                 previousItem.InventoryType == inventoryItem.InventoryType && previousItem.Amount == inventoryItem.Amount))
                return; //Equal
            DestroyAtSpot(index);
            if (inventoryItem == null || inventoryItem.Amount == 0)
                return;
            inventoryItemViews[index] = GetItemVisualization(inventoryItem);
            currentInventoryItems[index] = inventoryItem;
        }
        private GameObject GetItemVisualization(InventoryItem inventoryItem)
        {
            var ret= inventoryItem.InventoryType.GetViewObject();
            ret.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            return ret;
        }
        private void DestroyAtSpot(int index)
        {
            var toDestroy = inventoryItemViews[index];
            gameObjectManager.DestroyObj(toDestroy);
            currentInventoryItems[index] = null;
        }

        public void FocusOn(IslandElement islandElement)
        {
            if (islandElement == focussedOn)
                return;
            DestroyView();
            if (focussedOn != null)
                focussedOn.InventoryController.SetActiveToInventoryView(null);
            if (islandElement == null)
                return;
            CreateViewForIslandElement(islandElement);
            focussedOn = islandElement;
            if (focussedOn != null)
                focussedOn.InventoryController.SetActiveToInventoryView(this);
        }

        private void DestroyView()
        {
            if (view != null)
            {
                gameObjectManager.DestroyObj(view);
            }
            view = null;

        }

        public void CreateViewForIslandElement(IslandElement element)
        {
            if (element == null)
                return;
            view = gameObjectManager.LoadViaResources("Inventory");

            updateContainingInventory();
        }

        
        private void UseItemIfClicked()
        {
            Ray ray;
            RaycastHit hit;
            var camera = Camera.allCameras.First();
            ray = camera.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out hit))
                return;
            var hitPoint = hit.point;
            var gameObject = hit.collider.gameObject;
            if (!inventoryItemViews.Contains(gameObject))
                return;
            var useIndex = inventoryItemViews.IndexOf(gameObject);
            var itemToConsume = currentInventoryItems[useIndex];
            if (itemToConsume == null)
                return;
            focussedOn.InventoryController.ConsumeItem(itemToConsume);

        }
    }
}
