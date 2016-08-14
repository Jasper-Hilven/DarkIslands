using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitUnityViewFactory: IUnitElementFactory
  {
public Dictionary<Unit,UnitUnityView> Elements= new Dictionary<Unit,UnitUnityView>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new UnitUnityView(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
