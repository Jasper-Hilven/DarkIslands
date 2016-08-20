using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObjectHarvestController:WorldObjectHarvestControllerDefault
  {
    public WorldObjectHarvestController(WorldObject WorldObject, WorldObjectHarvestControllerFactory WorldObjectHarvestControllerFactory){
    Init(WorldObject, WorldObjectHarvestControllerFactory);
    }
  }
}
