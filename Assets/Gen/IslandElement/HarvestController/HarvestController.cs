using System.Collections.Generic;
namespace DarkIslands
{
  public partial class HarvestController:HarvestControllerDefault
  {
    public HarvestController(IslandElement IslandElement, HarvestControllerFactory HarvestControllerFactory){
    Init(IslandElement, HarvestControllerFactory);
    }
  }
}
