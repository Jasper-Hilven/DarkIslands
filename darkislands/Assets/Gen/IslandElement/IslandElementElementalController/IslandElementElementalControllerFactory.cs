using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementElementalControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementElementalController> Elements= new Dictionary<IslandElement,IslandElementElementalController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementElementalController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
