using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementMagicControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementMagicController> Elements= new Dictionary<IslandElement,IslandElementMagicController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementMagicController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
