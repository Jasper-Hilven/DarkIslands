using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementLightController:IslandElementLightControllerDefault
  {
    public IslandElementLightController(IslandElement IslandElement, IslandElementLightControllerFactory IslandElementLightControllerFactory){
    Init(IslandElement, IslandElementLightControllerFactory);
    }
  }
}
