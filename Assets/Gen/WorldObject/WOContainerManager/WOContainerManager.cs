using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOContainerManager:WOContainerManagerDefault
  {
    public WOContainerManager(WorldObject WorldObject, WOContainerManagerFactory WOContainerManagerFactory){
    Init(WorldObject, WOContainerManagerFactory);
    }
  }
}
