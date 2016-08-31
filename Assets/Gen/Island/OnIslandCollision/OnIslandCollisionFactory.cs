using System.Collections.Generic;
namespace DarkIslands
{
  public partial class OnIslandCollisionFactory: IIslandElementFactory
  {
public Dictionary<Island,OnIslandCollision> Elements= new Dictionary<Island,OnIslandCollision>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new OnIslandCollision(Island, this);
      Elements.Add(Island,element);
    }
  }
}
