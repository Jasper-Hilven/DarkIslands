using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandMovementControllerFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandMovementController> Elements= new Dictionary<Island,IslandMovementController>();

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandMovementController(Island, this);
      Elements.Add(Island,element);
      Island.ChangeSpeedListeners.Add(element);
    }
  }
}
