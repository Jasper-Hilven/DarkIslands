using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObjectFactory
  {
    public List<WorldObject> elements= new List<WorldObject>();
    public List<IWorldObjectElementFactory> SubFactories= new List<IWorldObjectElementFactory>();

    public WorldObject Create(){
      var ret= new WorldObject();
      elements.Add(ret);
      foreach (var subFactory in SubFactories)
        subFactory.ExtendWorldObject(ret);
      return ret;
    }

    public void DestroyWorldObject(WorldObject WorldObject){
      elements.Remove(WorldObject);
      foreach (var subFactory in SubFactories)
        subFactory.RemoveExtension(WorldObject);
    }
  }
  public interface IWorldObjectElementFactory{
    void ExtendWorldObject(WorldObject WorldObject);
    void RemoveExtension(WorldObject WorldObject);
  }
}
