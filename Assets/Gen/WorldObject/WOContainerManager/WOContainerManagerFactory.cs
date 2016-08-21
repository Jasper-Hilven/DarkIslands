using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOContainerManagerFactory: IWorldObjectElementFactory
  {
public Dictionary<WorldObject,WOContainerManager> Elements= new Dictionary<WorldObject,WOContainerManager>();

    public void RemoveExtension(WorldObject WorldObject){
      var element = Elements[WorldObject];
      element.Destroy();
      Elements.Remove(WorldObject);
    }

    public void ExtendWorldObject(WorldObject WorldObject){
      var element =new WOContainerManager(WorldObject, this);
      Elements.Add(WorldObject,element);
      WorldObject.ChangeListeners.Add(element);
    }
  }
}
