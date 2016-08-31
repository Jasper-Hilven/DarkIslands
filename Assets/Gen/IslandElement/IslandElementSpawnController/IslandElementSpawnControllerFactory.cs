using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementSpawnControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementSpawnController> Elements= new Dictionary<IslandElement,IslandElementSpawnController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementSpawnController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeListeners.Add(element);
    }
  }
}
