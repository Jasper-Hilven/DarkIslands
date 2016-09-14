using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementTeamController:IslandElementTeamControllerDefault
  {
    public IslandElementTeamController(IslandElement IslandElement, IslandElementTeamControllerFactory IslandElementTeamControllerFactory){
    Init(IslandElement, IslandElementTeamControllerFactory);
    }
  }
}
