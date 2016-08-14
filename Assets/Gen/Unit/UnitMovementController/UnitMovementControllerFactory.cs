using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitMovementControllerFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitMovementController> Elements= new Dictionary<Unit,UnitMovementController>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitMovementController(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
