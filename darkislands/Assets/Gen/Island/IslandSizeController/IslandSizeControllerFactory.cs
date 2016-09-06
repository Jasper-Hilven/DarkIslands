using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandSizeControllerFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandSizeController> Elements= new Dictionary<Island,IslandSizeController>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandSizeController(Island, this);
      Elements.Add(Island,element);
    }
  }
}
