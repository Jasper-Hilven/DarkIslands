using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ItemUsageControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,ItemUsageController> Elements= new Dictionary<IslandElement,ItemUsageController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new ItemUsageController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
