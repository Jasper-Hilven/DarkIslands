using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DarkIslandGen.DemoModel
{
    public interface IShipElementFactory
    {
        void ExtendShip(Ship ship);
        void RemoveExtension(Ship ship);
    }
    public class ShipFactory
    {
        public List<Ship> Elements= new List<Ship>();
        public List<IShipElementFactory>SubFactories= new List<IShipElementFactory>();  
        public Ship Create(MyType p)
        {
            var ret= new Ship(p);
            Elements.Add(ret);
            foreach (var subFactory in SubFactories)
                subFactory.ExtendShip(ret);
            return ret;
        }

        public void Destroy(Ship ship)
        {
            foreach (var subFactory in SubFactories)
                subFactory.RemoveExtension(ship);
            Elements.Remove(ship);
        }
    }
}