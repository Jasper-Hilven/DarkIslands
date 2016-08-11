using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipPlayerControllerFactory: IShipElementFactory
  {
public Dictionary<Ship,ShipPlayerController> Elements= new Dictionary<Ship,ShipPlayerController>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ShipPlayerController(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
