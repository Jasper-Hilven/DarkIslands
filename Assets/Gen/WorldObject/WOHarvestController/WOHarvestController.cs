using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOHarvestController:WOHarvestControllerDefault
  {
    public WOHarvestController(WorldObject WorldObject, WOHarvestControllerFactory WOHarvestControllerFactory){
    Init(WorldObject, WOHarvestControllerFactory);
    }
  }
}
