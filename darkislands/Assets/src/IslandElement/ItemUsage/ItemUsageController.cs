using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DarkIslands
{
    public partial class ItemUsageController
    {
        private IslandElement elem;

        public override void Init(IslandElement IslandElement, ItemUsageControllerFactory ItemUsageControllerFactory)
        {
            IslandElement.ItemUsageController = this;
            this.elem = IslandElement;
        }
        public IItemUsageControllerTactic usageTactic;

        public void UseItem(InventoryItem item)
        {
            if (usageTactic == null)
                return;
            usageTactic.UseItem(elem, item);
        }
    }
    public interface IItemUsageControllerTactic
    {
        void UseItem(IslandElement elem,InventoryItem item);
    }
    public class WizardItemUsageControllerTactic : IItemUsageControllerTactic
    {
        private InventoryDatabase database;

        public WizardItemUsageControllerTactic(InventoryDatabase database)
        {
            this.database = database;
        }
        public void UseItem(IslandElement elem, InventoryItem item)
        {
            if (item.InventoryType == database.BrownMushroom)
                elem.MagicController.AddMana(item.Amount * 5);
            if (item.InventoryType == database.Stone)
                elem.LifeController.Heal(item.Amount * 5);
            if (item.InventoryType == database.Wood)
                elem.HydrationController.Hydrate(item.Amount * 5);
        }
    }
}
