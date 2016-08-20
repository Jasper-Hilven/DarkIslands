using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IWOContainerControllerShipFactory: IShipElementFactory
  {
public Dictionary<Ship,IWOContainerControllerShip> Elements= new Dictionary<Ship,IWOContainerControllerShip>();

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new IWOContainerControllerShip(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
