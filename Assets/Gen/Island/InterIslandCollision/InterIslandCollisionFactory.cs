using System.Collections.Generic;
namespace DarkIslands
{
  public partial class InterIslandCollisionFactory: IIslandElementFactory
  {
public Dictionary<Island,InterIslandCollision> Elements= new Dictionary<Island,InterIslandCollision>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new InterIslandCollision(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
