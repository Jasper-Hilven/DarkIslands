using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipUnityViewFactory: IShipElementFactory
  {
public Dictionary<Ship,ShipUnityView> Elements= new Dictionary<Ship,ShipUnityView>();
    public ModelToEntity ModelToEntity;

    public ShipUnityViewFactory(ModelToEntity ModelToEntity){
      this.ModelToEntity= ModelToEntity;
    }

    public void RemoveExtension(Ship Ship){
      var element = Elements[Ship];
      element.Destroy();
      Elements.Remove(Ship);
    }

    public void ExtendShip(Ship Ship){
      var element =new ShipUnityView(Ship, this);
      Elements.Add(Ship,element);
      Ship.ChangeListeners.Add(element);
    }
  }
}
