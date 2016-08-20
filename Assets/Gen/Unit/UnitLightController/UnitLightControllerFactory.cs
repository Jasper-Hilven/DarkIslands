using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitLightControllerFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitLightController> Elements= new Dictionary<Unit,UnitLightController>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitLightController(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }

  }
}
