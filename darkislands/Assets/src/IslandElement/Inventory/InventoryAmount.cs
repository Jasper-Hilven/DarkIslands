using System.Collections.Generic;
using System.Linq;

namespace DarkIslands
{
    public class InventoryAmount
    {
        public InventoryAmount(Dictionary<InventoryType, int> Amount)
        {
            this.Amount = Amount;
        }

        public InventoryAmount()
        {
            this.Amount= new Dictionary<InventoryType, int>();
        }

        public bool Empty()
        {
            return this.Amount.All(cP => cP.Value == 0);
        }
        public Dictionary<InventoryType,int> Amount { get; set;}  
    }
}