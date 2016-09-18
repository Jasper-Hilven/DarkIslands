using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementDropOffControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementDropOffController> Elements= new Dictionary<IslandElement,IslandElementDropOffController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementDropOffController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeRelativeToContainerPositionListeners.Add(element);
    }
  }
}
