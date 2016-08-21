using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WOHarvestControllerFactory: IWorldObjectElementFactory
  {
public Dictionary<WorldObject,WOHarvestController> Elements= new Dictionary<WorldObject,WOHarvestController>();

    public void RemoveExtension(WorldObject WorldObject){
      var element = Elements[WorldObject];
      element.Destroy();
      Elements.Remove(WorldObject);
    }

    public void ExtendWorldObject(WorldObject WorldObject){
      var element =new WOHarvestController(WorldObject, this);
      Elements.Add(WorldObject,element);
      WorldObject.ChangeListeners.Add(element);
    }
  }
}
