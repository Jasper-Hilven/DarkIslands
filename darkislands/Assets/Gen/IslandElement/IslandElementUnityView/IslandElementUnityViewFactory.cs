using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementUnityViewFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementUnityView> Elements= new Dictionary<IslandElement,IslandElementUnityView>();
    public ModelToEntity ModelToEntity;

    public IslandElementUnityViewFactory(ModelToEntity ModelToEntity){
      this.ModelToEntity= ModelToEntity;
    }

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementUnityView(IslandElement, this);
      Elements.Add(IslandElement,element);
      IslandElement.ChangeIslandElementViewSettingsListeners.Add(element);
      IslandElement.ChangeIsElementalColoredListeners.Add(element);
      IslandElement.ChangeElementalTypeListeners.Add(element);
      IslandElement.ChangePositionListeners.Add(element);
      IslandElement.ChangeSizeListeners.Add(element);
      IslandElement.ChangeRotationListeners.Add(element);
    }
  }
}
