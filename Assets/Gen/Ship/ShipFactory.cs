using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipFactory
  {
    public List<Ship> elements= new List<Ship>();
    public List<IShipElementFactory> SubFactories= new List<IShipElementFactory>();

    public Ship Create(){
      var ret= new Ship();
      elements.Add(ret);
      foreach (var subFactory in SubFactories)
        subFactory.ExtendShip(ret);
      return ret;
    }

    public void DestroyShip(Ship Ship){
      elements.Remove(Ship);
      foreach (var subFactory in SubFactories)
        subFactory.RemoveExtension(Ship);
    }
  }
  public interface IShipElementFactory{
    void ExtendShip(Ship Ship);
    void RemoveExtension(Ship Ship);
  }
}
