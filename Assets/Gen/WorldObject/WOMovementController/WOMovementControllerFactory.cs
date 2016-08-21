using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOMovementControllerFactory: IWorldObjectElementFactory
  {
public Dictionary<WorldObject,WOMovementController> Elements= new Dictionary<WorldObject,WOMovementController>();

    public void RemoveExtension(WorldObject WorldObject){
      var element = Elements[WorldObject];
      element.Destroy();
      Elements.Remove(WorldObject);
    }

    public void ExtendWorldObject(WorldObject WorldObject){
      var element =new WOMovementController(WorldObject, this);
      Elements.Add(WorldObject,element);
      WorldObject.ChangeListeners.Add(element);
    }
  }
}
