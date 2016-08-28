using System.Collections.Generic;
namespace DarkIslands
{
  public partial class HarvestControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,HarvestController> Elements= new Dictionary<IslandElement,HarvestController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new HarvestController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeListeners.Add(element);
    }
  }
}
