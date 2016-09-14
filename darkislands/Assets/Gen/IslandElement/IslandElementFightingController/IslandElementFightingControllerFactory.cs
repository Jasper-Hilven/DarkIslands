using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementFightingControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementFightingController> Elements= new Dictionary<IslandElement,IslandElementFightingController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementFightingController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
