using System.Collections.Generic;
namespace DarkIslands
{
  public partial class LifeControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,LifeController> Elements= new Dictionary<IslandElement,LifeController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new LifeController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
