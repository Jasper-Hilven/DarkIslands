using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObjectUnityViewFactory: IWorldObjectElementFactory
  {
public Dictionary<WorldObject,WorldObjectUnityView> Elements= new Dictionary<WorldObject,WorldObjectUnityView>();
    public ModelToEntity ModelToEntity;

    public WorldObjectUnityViewFactory(ModelToEntity ModelToEntity){
      this.ModelToEntity= ModelToEntity;
    }

    public void RemoveExtension(WorldObject WorldObject){
      var element = Elements[WorldObject];
      element.Destroy();
      Elements.Remove(WorldObject);
    }

    public void ExtendWorldObject(WorldObject WorldObject){
      var element =new WorldObjectUnityView(WorldObject, this);
      Elements.Add(WorldObject,element);
      WorldObject.ChangeListeners.Add(element);
    }
  }
}
