using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public partial class InventoryController
    {
        public IslandElement IslandElement { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public bool HasInventory
        {
            get
            {
                return Inventory != null;
            }
            set
            {
                if (value)
                    this.Inventory = Inventory ?? new List<InventoryItem>() {null,null,null,null,null,null,null,null,null,null,null,null };
                else
                    Inventory = null;
            }
        }
        private InventoryViewFacade view;
        public override void Init(IslandElement IslandElement, InventoryControllerFactory InventoryControllerFactory)
        {
            base.Init(IslandElement, InventoryControllerFactory);
            this.IslandElement = IslandElement;
            this.IslandElement.InventoryController = this;

            UpdateView();
        }

        public void SetActiveToInventoryView(InventoryViewFacade view)
        {
            this.view = view;
        }
        private void UpdateView()
        {
            if (view == null)
                return;
            view.UpdateInventoryFromGameLogicToUnity();
        }
        public void ReceiveView(List<InventoryItem> Inventory)
        {
            this.Inventory = Inventory;
        }

        public void AddItem(InventoryItem item)
        {
            var remainder = AddToExisting(item);
            if (remainder.Amount != 0)
                remainder = AddToEmptySlot(remainder);
            EnsureListSize();
            UpdateView();
        }

        private InventoryItem AddToExisting(InventoryItem item)
        {
            var remainder = item;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (remainder.Amount == 0)
                    return remainder;
                var atI = Inventory[i];
                if (atI == null)
                    continue;
                if (atI.InventoryType != item.InventoryType)
                    continue;
                if (atI.Amount >= atI.InventoryType.maxStack)
                    continue;
                var canAddToStack = atI.InventoryType.maxStack - atI.Amount;
                var toAdd = Math.Min(remainder.Amount, canAddToStack);
                if (toAdd == 0)
                    continue;
                atI.Amount += toAdd;
                remainder.Amount -= toAdd;
            }
            return remainder;
        }
        private InventoryItem AddToEmptySlot(InventoryItem item)
        {
            var remainder = item;
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (remainder.Amount == 0)
                    return remainder;
                var atI = Inventory[i];
                if (atI != null)
                    continue;
                var toAdd = Math.Min(remainder.Amount, remainder.InventoryType.maxStack);
                if (toAdd == 0)
                    continue;
                Inventory[i] = remainder.TakeOffAmount(toAdd);
            }
            return remainder;
        }

        public void EnsureListSize()
        {
            if(Inventory.Count > 12)
            {
                Inventory = Inventory.Take(12).ToList();
            }
        }
       
        public void AddResources(ResourceAmount resHarvested)
        {
            EnsureListSize();
            if (resHarvested.Empty)
                return;
            foreach (var resource in resHarvested.Amount)
            {
                var invType = resource.Key.ToInventory();
                var amount = resource.Value;
                if(amount > 0)
                    AddItem(new InventoryItem(invType, amount));
            }
            UpdateView();
        }

        public void ConsumeItem(InventoryItem myItem)
        {
            myItem.Amount--;
            if (myItem.Amount == 0)
                Inventory.Remove(myItem);
            UpdateView();

        }
    }
}