using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ItemUsageController:ItemUsageControllerDefault
  {
    public ItemUsageController(IslandElement IslandElement, ItemUsageControllerFactory ItemUsageControllerFactory){
    Init(IslandElement, ItemUsageControllerFactory);
    }
  }
}
