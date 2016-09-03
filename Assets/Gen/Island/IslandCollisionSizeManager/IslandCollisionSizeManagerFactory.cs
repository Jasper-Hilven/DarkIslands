using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandCollisionSizeManagerFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandCollisionSizeManager> Elements= new Dictionary<Island,IslandCollisionSizeManager>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandCollisionSizeManager(Island, this);
      Elements.Add(Island,element);
      Island.ChangeSizeListeners.Add(element);
    }
  }
}
