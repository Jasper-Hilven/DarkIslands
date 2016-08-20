using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObjectHarvestControllerFactory: IWorldObjectElementFactory
  {
public Dictionary<WorldObject,WorldObjectHarvestController> Elements= new Dictionary<WorldObject,WorldObjectHarvestController>();

    public void RemoveExtension(WorldObject WorldObject){
      var element = Elements[WorldObject];
      element.Destroy();
      Elements.Remove(WorldObject);
    }

    public void ExtendWorldObject(WorldObject WorldObject){
      var element =new WorldObjectHarvestController(WorldObject, this);
      Elements.Add(WorldObject,element);
      WorldObject.ChangeListeners.Add(element);
    }
  }
}
