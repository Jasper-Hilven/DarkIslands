using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementHoverControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementHoverController> Elements= new Dictionary<IslandElement,IslandElementHoverController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementHoverController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
