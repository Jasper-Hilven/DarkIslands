using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementLightControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementLightController> Elements= new Dictionary<IslandElement,IslandElementLightController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementLightController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangehasLightListeners.Add(element);
      IslandElement.ChangePositionListeners.Add(element);
    }
  }
}
