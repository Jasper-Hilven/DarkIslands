using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementElementalViewFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementElementalView> Elements= new Dictionary<IslandElement,IslandElementElementalView>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementElementalView(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeIsElementalColoredListeners.Add(element);
      IslandElement.ChangehasElementalViewListeners.Add(element);
      IslandElement.ChangeElementalInfoListeners.Add(element);
      IslandElement.ChangeElementalTypeListeners.Add(element);
    }
  }
}
