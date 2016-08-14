using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipSelectedViewFactory: IShipElementFactory
  {
public Dictionary<Ship,ShipSelectedView> Elements= new Dictionary<Ship,ShipSelectedView>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ShipSelectedView(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
