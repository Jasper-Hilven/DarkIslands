using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementUnityAnimationControllerFactory: IIslandElementElementFactory
  {
public Dictionary<IslandElement,IslandElementUnityAnimationController> Elements= new Dictionary<IslandElement,IslandElementUnityAnimationController>();
    public ModelToEntity ModelToEntity;

    public IslandElementUnityAnimationControllerFactory(ModelToEntity ModelToEntity){
      this.ModelToEntity= ModelToEntity;
    }

    public void RemoveExtension(IslandElement IslandElement){
      var element = Elements[IslandElement];
      element.Destroy();
      Elements.Remove(IslandElement);
    }

    public void ExtendIslandElement(IslandElement IslandElement){
      var element =new IslandElementUnityAnimationController(IslandElement, this);
      Elements.Add(IslandElement,element);
    }
  }
}
