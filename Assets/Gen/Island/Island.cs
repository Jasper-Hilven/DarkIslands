using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Island
  {
  public List<IIslandChanged> ChangeListeners= new List<IIslandChanged>();
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public float Size
    {
      get{
        return _Size;
      }
      set
      {
        this._Size= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.SizeChanged();
      }
    }
      private float _Size{get;set;}
    public ContainerControllerIsland ContainerControllerIsland
    {
      get{
        return _ContainerControllerIsland;
      }
      set
      {
        this._ContainerControllerIsland= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.ContainerControllerIslandChanged();
      }
    }
      private ContainerControllerIsland _ContainerControllerIsland{get;set;}
    public OnIslandCollision IslandCollision
    {
      get{
        return _IslandCollision;
      }
      set
      {
        this._IslandCollision= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.IslandCollisionChanged();
      }
    }
      private OnIslandCollision _IslandCollision{get;set;}
    public CircleElementProperties CircleElementProperties
    {
      get{
        return _CircleElementProperties;
      }
      set
      {
        this._CircleElementProperties= value;
        foreach( var vIslandChanged in ChangeListeners)
          vIslandChanged.CircleElementPropertiesChanged();
      }
    }
      private CircleElementProperties _CircleElementProperties{get;set;}
  }
}
