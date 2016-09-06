using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementMovementControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementMovementController> Elements= new Dictionary<IslandElement,IslandElementMovementController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementMovementController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeRelativeToContainerPositionListeners.Add(element);
      IslandElement.ChangeRelativeGoalPositionListeners.Add(element);
      IslandElement.ChangeHasRelativeGoalPositionListeners.Add(element);
      IslandElement.ChangeIslandPositionListeners.Add(element);
      IslandElement.ChangeIslandListeners.Add(element);
    }
  }
}
