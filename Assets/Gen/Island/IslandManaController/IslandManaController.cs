using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandManaController:IslandManaControllerDefault
  {
    public IslandManaController(Island Island, IslandManaControllerFactory IslandManaControllerFactory){
    Init(Island, IslandManaControllerFactory);
    }
  }
}
