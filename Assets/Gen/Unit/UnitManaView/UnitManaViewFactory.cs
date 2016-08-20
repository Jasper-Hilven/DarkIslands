using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitManaViewFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitManaView> Elements= new Dictionary<Unit,UnitManaView>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitManaView(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
