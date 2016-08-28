using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementMovementControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementMovementController> Elements= new Dictionary<IslandElement,IslandElementMovementController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementMovementController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeListeners.Add(element);
    }
  }
}
