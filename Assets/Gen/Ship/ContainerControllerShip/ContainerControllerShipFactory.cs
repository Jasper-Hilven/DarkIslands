using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainerControllerShipFactory: IShipElementFactory
  {
public Dictionary<Ship,ContainerControllerShip> Elements= new Dictionary<Ship,ContainerControllerShip>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ContainerControllerShip(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
