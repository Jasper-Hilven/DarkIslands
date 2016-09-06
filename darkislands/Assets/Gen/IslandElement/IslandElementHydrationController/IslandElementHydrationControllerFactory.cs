using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementHydrationControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementHydrationController> Elements= new Dictionary<IslandElement,IslandElementHydrationController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementHydrationController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeCanDehydrateListeners.Add(element);
    }
  }
}
