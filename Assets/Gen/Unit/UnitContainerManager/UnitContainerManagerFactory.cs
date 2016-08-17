using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitContainerManagerFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitContainerManager> Elements= new Dictionary<Unit,UnitContainerManager>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitContainerManager(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
