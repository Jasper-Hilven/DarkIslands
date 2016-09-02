using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementSizeController:IslandElementSizeControllerDefault
  {
    public IslandElementSizeController(IslandElement IslandElement, IslandElementSizeControllerFactory IslandElementSizeControllerFactory){
    Init(IslandElement, IslandElementSizeControllerFactory);
    }
  }
}
