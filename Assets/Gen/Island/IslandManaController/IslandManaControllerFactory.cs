using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandManaControllerFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandManaController> Elements= new Dictionary<Island,IslandManaController>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandManaController(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
