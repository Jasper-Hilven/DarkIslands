using System.Collections.Generic;
namespace DarkIslands
{
  public partial class InventoryControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,InventoryController> Elements= new Dictionary<IslandElement,InventoryController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new InventoryController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
