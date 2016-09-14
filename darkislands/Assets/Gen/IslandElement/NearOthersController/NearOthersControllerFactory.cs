using System.Collections.Generic;
namespace DarkIslands
{
  public partial class NearOthersControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,NearOthersController> Elements= new Dictionary<IslandElement,NearOthersController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new NearOthersController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeRelativeToContainerPositionListeners.Add(element);
    }
  }
}
