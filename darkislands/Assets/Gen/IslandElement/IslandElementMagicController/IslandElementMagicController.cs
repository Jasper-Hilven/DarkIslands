using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementMagicController:IslandElementMagicControllerDefault
  {
    public IslandElementMagicController(IslandElement IslandElement, IslandElementMagicControllerFactory IslandElementMagicControllerFactory){
    Init(IslandElement, IslandElementMagicControllerFactory);
    }
  }
}
