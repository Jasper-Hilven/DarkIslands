using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementContainerManagerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementContainerManager> Elements= new Dictionary<IslandElement,IslandElementContainerManager>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementContainerManager(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeIslandToEnterListeners.Add(element);
      IslandElement.ChangeIslandPositionListeners.Add(element);
      IslandElement.ChangeRelativeToContainerPositionListeners.Add(element);
    }
  }
}
