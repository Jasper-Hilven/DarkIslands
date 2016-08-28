using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementActionHandlerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementActionHandler> Elements= new Dictionary<IslandElement,IslandElementActionHandler>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementActionHandler(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeListeners.Add(element);
    }
  }
}
