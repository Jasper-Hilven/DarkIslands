using System.Collections.Generic;
namespace DarkIslands
{
  public partial class CollisionSizeManagerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,CollisionSizeManager> Elements= new Dictionary<IslandElement,CollisionSizeManager>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new CollisionSizeManager(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeSizeListeners.Add(element);
    }
  }
}
