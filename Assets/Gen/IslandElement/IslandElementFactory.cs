using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElementFactory
  {
    public List<IslandElement> elements= new List<IslandElement>();
    public List<IIslandElementElementFactory> SubFactories= new List<IIslandElementElementFactory>();

    public IslandElement Create(){
      var ret= new IslandElement();
      elements.Add(ret);
      foreach (var subFactory in SubFactories)
        subFactory.ExtendIslandElement(ret);
      return ret;
    }

    public void DestroyIslandElement(IslandElement IslandElement){
      elements.Remove(IslandElement);
      foreach (var subFactory in SubFactories)
        subFactory.RemoveExtension(IslandElement);
    }
  }
  public interface IIslandElementElementFactory{
    void ExtendIslandElement(IslandElement IslandElement);
    void RemoveExtension(IslandElement IslandElement);
  }
}
