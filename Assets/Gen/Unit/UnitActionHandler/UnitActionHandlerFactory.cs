using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitActionHandlerFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitActionHandler> Elements= new Dictionary<Unit,UnitActionHandler>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitActionHandler(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
