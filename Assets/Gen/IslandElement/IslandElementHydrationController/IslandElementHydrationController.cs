using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementHydrationController:IslandElementHydrationControllerDefault
  {
    public IslandElementHydrationController(IslandElement IslandElement, IslandElementHydrationControllerFactory IslandElementHydrationControllerFactory){
    Init(IslandElement, IslandElementHydrationControllerFactory);
    }
  }
}
