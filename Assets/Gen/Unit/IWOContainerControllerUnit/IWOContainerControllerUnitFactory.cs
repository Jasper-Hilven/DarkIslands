using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerUnitFactory: IUnitElementFactory
  {
public Dictionary<Unit,IWOContainerControllerUnit> Elements= new Dictionary<Unit,IWOContainerControllerUnit>();

    public void RemoveExtension(Unit Unit){
      var element = Elements[Unit];
      element.Destroy();
      Elements.Remove(Unit);
    }

    public void ExtendUnit(Unit Unit){
      var element =new IWOContainerControllerUnit(Unit, this);
      Elements.Add(Unit,element);
      Unit.ChangeListeners.Add(element);
    }
  }
}
