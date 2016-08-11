using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandFactory
  {
    public List<Island> elements= new List<Island>();
    public List<IIslandElementFactory> SubFactories= new List<IIslandElementFactory>();

    public Island Create(){
      var ret= new Island();
      elements.Add(ret);
      foreach (var subFactory in SubFactories)
        subFactory.ExtendIsland(ret);
      return ret;
    }

    public void DestroyIsland(Island Island){
      elements.Remove(Island);
      foreach (var subFactory in SubFactories)
        subFactory.RemoveExtension(Island);
    }
  }
  public interface IIslandElementFactory{
    void ExtendIsland(Island Island);
    void RemoveExtension(Island Island);
  }
}
