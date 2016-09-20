using System.Collections.Generic;
namespace DarkIslands
{
  public partial class OnIslandNearityControllerFactory: IIslandElementFactory
  {
public Dictionary<Island,OnIslandNearityController> Elements= new Dictionary<Island,OnIslandNearityController>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new OnIslandNearityController(Island, this);
      Elements.Add(Island,element);
    }
  }
}
