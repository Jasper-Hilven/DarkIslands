using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementHoverController:IslandElementHoverControllerDefault
  {
    public IslandElementHoverController(IslandElement IslandElement, IslandElementHoverControllerFactory IslandElementHoverControllerFactory){
    Init(IslandElement, IslandElementHoverControllerFactory);
    }
  }
}
