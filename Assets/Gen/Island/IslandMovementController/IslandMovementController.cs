using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandMovementController:IslandMovementControllerDefault
  {
    public IslandMovementController(Island Island, IslandMovementControllerFactory IslandMovementControllerFactory){
    Init(Island, IslandMovementControllerFactory);
    }
  }
}
