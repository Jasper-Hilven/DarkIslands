using System.Collections.Generic;
namespace DarkIslands
{
  public partial class InventoryController:InventoryControllerDefault
  {
    public InventoryController(IslandElement IslandElement, InventoryControllerFactory InventoryControllerFactory){
    Init(IslandElement, InventoryControllerFactory);
    }
  }
}
