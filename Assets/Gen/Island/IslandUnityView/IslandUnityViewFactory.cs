using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandUnityViewFactory: IIslandElementFactory
  {
public Dictionary<Island,IslandUnityView> Elements= new Dictionary<Island,IslandUnityView>();
    public ModelToEntity ModelToEntity;

    public IslandUnityViewFactory(ModelToEntity ModelToEntity){
      this.ModelToEntity= ModelToEntity;
    }

    public void RemoveExtension(Island Island){
      var element = Elements[Island];
      element.Destroy();
      Elements.Remove(Island);
    }

    public void ExtendIsland(Island Island){
      var element =new IslandUnityView(Island, this);
      Elements.Add(Island,element);
      Island.ChangeListeners.Add(element);
    }
  }
}
