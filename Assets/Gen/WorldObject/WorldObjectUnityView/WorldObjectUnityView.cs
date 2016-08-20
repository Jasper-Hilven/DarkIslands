using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObjectUnityView:WorldObjectUnityViewDefault
  {
    public WorldObjectUnityView(WorldObject WorldObject, WorldObjectUnityViewFactory WorldObjectUnityViewFactory){
    Init(WorldObject, WorldObjectUnityViewFactory);
    }
  }
}
