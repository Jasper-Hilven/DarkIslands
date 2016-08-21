using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerIsland:IWOContainerControllerIslandDefault
  {
    public IWOContainerControllerIsland(Island Island, IWOContainerControllerIslandFactory IWOContainerControllerIslandFactory){
    Init(Island, IWOContainerControllerIslandFactory);
    }
  }
}
