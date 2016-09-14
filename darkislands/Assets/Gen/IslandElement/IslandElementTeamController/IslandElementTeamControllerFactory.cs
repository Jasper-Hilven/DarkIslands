using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementTeamControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementTeamController> Elements= new Dictionary<IslandElement,IslandElementTeamController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementTeamController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
