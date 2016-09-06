using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementLifeControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementLifeController> Elements= new Dictionary<IslandElement,IslandElementLifeController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementLifeController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
