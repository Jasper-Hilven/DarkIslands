using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementContainerManager:IslandElementContainerManagerDefault
  {
    public IslandElementContainerManager(IslandElement IslandElement, IslandElementContainerManagerFactory IslandElementContainerManagerFactory){
    Init(IslandElement, IslandElementContainerManagerFactory);
    }
  }
}
