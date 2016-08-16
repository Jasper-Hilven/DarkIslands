using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainerControllerIsland:ContainerControllerIslandDefault
  {
    public ContainerControllerIsland(Island Island, ContainerControllerIslandFactory ContainerControllerIslandFactory){
    Init(Island, ContainerControllerIslandFactory);
    }
  }
}
