using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandSelectionController:IslandSelectionControllerDefault
  {
    public IslandSelectionController(IslandElement IslandElement, IslandSelectionControllerFactory IslandSelectionControllerFactory){
    Init(IslandElement, IslandSelectionControllerFactory);
    }
  }
}
