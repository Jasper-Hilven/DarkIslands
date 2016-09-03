using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementDropOffController:IslandElementDropOffControllerDefault
  {
    public IslandElementDropOffController(IslandElement IslandElement, IslandElementDropOffControllerFactory IslandElementDropOffControllerFactory){
    Init(IslandElement, IslandElementDropOffControllerFactory);
    }
  }
}
