using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitContainerControllerFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitContainerController> Elements= new Dictionary<Unit,UnitContainerController>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitContainerController(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
