using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementLifeController:IslandElementLifeControllerDefault
  {
    public IslandElementLifeController(IslandElement IslandElement, IslandElementLifeControllerFactory IslandElementLifeControllerFactory){
    Init(IslandElement, IslandElementLifeControllerFactory);
    }
  }
}
