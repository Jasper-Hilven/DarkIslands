using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipMovementControllerFactory: IShipElementFactory
  {
public Dictionary<Ship,ShipMovementController> Elements= new Dictionary<Ship,ShipMovementController>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ShipMovementController(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
