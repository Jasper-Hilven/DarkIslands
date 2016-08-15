using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainingUnitsControllerFactory: IShipElementFactory
  {
public Dictionary<Ship,ContainingUnitsController> Elements= new Dictionary<Ship,ContainingUnitsController>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ContainingUnitsController(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
