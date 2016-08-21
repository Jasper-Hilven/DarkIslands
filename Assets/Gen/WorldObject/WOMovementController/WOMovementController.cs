using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOMovementController:WOMovementControllerDefault
  {
    public WOMovementController(WorldObject WorldObject, WOMovementControllerFactory WOMovementControllerFactory){
    Init(WorldObject, WOMovementControllerFactory);
    }
  }
}
