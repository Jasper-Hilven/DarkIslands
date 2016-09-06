using System.Collections.Generic;

namespace DarkIslandGen.DemoModel
{
    public class ShipViewModelFactory: IShipElementFactory
    {
        public Dictionary<Ship, ShipViewModel> Elements = new Dictionary<Ship, ShipViewModel>();

        public void ExtendShip(Ship ship)
        {
            var element= new ShipViewModel(ship);
            Elements.Add(ship,element);
            ship.ChangeListeners.Add(element);
        }

        public void RemoveExtension(Ship ship)
        {
            var element = Elements[ship];
            element.Destroy();
            Elements.Remove(ship);

        }
    }
}