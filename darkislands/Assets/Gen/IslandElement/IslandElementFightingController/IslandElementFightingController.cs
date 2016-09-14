using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementFightingController:IslandElementFightingControllerDefault
  {
    public IslandElementFightingController(IslandElement IslandElement, IslandElementFightingControllerFactory IslandElementFightingControllerFactory){
    Init(IslandElement, IslandElementFightingControllerFactory);
    }
  }
}
