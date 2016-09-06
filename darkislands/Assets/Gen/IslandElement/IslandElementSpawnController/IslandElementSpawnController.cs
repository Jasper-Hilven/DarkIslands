using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementSpawnController:IslandElementSpawnControllerDefault
  {
    public IslandElementSpawnController(IslandElement IslandElement, IslandElementSpawnControllerFactory IslandElementSpawnControllerFactory){
    Init(IslandElement, IslandElementSpawnControllerFactory);
    }
  }
}
