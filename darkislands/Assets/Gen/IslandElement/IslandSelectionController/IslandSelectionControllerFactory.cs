using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandSelectionControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandSelectionController> Elements= new Dictionary<IslandElement,IslandSelectionController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandSelectionController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
