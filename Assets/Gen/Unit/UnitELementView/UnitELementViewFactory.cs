using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitELementViewFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitELementView> Elements= new Dictionary<Unit,UnitELementView>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitELementView(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
