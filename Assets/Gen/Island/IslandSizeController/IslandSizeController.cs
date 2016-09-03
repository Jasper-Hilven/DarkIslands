using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandSizeController:IslandSizeControllerDefault
  {
    public IslandSizeController(Island Island, IslandSizeControllerFactory IslandSizeControllerFactory){
    Init(Island, IslandSizeControllerFactory);
    }
  }
}
