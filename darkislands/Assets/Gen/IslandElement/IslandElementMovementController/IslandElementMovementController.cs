using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementMovementController:IslandElementMovementControllerDefault
  {
    public IslandElementMovementController(IslandElement IslandElement, IslandElementMovementControllerFactory IslandElementMovementControllerFactory){
    Init(IslandElement, IslandElementMovementControllerFactory);
    }
  }
}
