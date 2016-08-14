using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitFactory
  {
    public List<Unit> elements= new List<Unit>();
    public List<IUnitElementFactory> SubFactories= new List<IUnitElementFactory>();

    public Unit Create(){
      var ret= new Unit();
      elements.Add(ret);
      foreach (var subFactory in SubFactories)
        subFactory.ExtendUnit(ret);
      return ret;
    }

    public void DestroyUnit(Unit Unit){
      elements.Remove(Unit);
      foreach (var subFactory in SubFactories)
        subFactory.RemoveExtension(Unit);
    }
  }
  public interface IUnitElementFactory{
    void ExtendUnit(Unit Unit);
    void RemoveExtension(Unit Unit);
  }
}
