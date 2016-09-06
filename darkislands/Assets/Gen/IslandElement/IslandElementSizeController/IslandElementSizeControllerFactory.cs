using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementSizeControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementSizeController> Elements= new Dictionary<IslandElement,IslandElementSizeController>();

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementSizeController(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeHarvestInfoListeners.Add(element);
      IslandElement.ChangeSizeControllerListeners.Add(element);
    }
  }
}
