using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Island
  {
  public List<IIslandPositionChanged> ChangePositionListeners= new List<IIslandPositionChanged>();
  public List<IIslandSizeChanged> ChangeSizeListeners= new List<IIslandSizeChanged>();
  public List<IIslandMassChanged> ChangeMassListeners= new List<IIslandMassChanged>();
  public List<IIslandSizeControllerChanged> ChangeSizeControllerListeners= new List<IIslandSizeControllerChanged>();
  public List<IIslandSpeedChanged> ChangeSpeedListeners= new List<IIslandSpeedChanged>();
  public List<IIslandContainerControllerIslandChanged> ChangeContainerControllerIslandListeners= new List<IIslandContainerControllerIslandChanged>();
  public List<IIslandIslandCollisionChanged> ChangeIslandCollisionListeners= new List<IIslandIslandCollisionChanged>();
  public List<IIslandCircleElementPropertiesChanged> ChangeCircleElementPropertiesListeners= new List<IIslandCircleElementPropertiesChanged>();
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vIslandPositionChanged in ChangePositionListeners)
          vIslandPositionChanged.PositionChanged();
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
        foreach( var vIslandSizeChanged in ChangeSizeListeners)
          vIslandSizeChanged.SizeChanged();
      }
    }
      private float _Size{get;set;}
    public float Mass
    {
      get{
        return _Mass;
      }
      set
      {
        this._Mass= value;
        foreach( var vIslandMassChanged in ChangeMassListeners)
          vIslandMassChanged.MassChanged();
      }
    }
      private float _Mass{get;set;}
    public IslandSizeController SizeController
    {
      get{
        return _SizeController;
      }
      set
      {
        this._SizeController= value;
        foreach( var vIslandSizeControllerChanged in ChangeSizeControllerListeners)
          vIslandSizeControllerChanged.SizeControllerChanged();
      }
    }
      private IslandSizeController _SizeController{get;set;}
    public float Speed
    {
      get{
        return _Speed;
      }
      set
      {
        this._Speed= value;
        foreach( var vIslandSpeedChanged in ChangeSpeedListeners)
          vIslandSpeedChanged.SpeedChanged();
      }
    }
      private float _Speed{get;set;}
    public ContainerControllerIsland ContainerControllerIsland
    {
      get{
        return _ContainerControllerIsland;
      }
      set
      {
        this._ContainerControllerIsland= value;
        foreach( var vIslandContainerControllerIslandChanged in ChangeContainerControllerIslandListeners)
          vIslandContainerControllerIslandChanged.ContainerControllerIslandChanged();
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
        foreach( var vIslandIslandCollisionChanged in ChangeIslandCollisionListeners)
          vIslandIslandCollisionChanged.IslandCollisionChanged();
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
        foreach( var vIslandCircleElementPropertiesChanged in ChangeCircleElementPropertiesListeners)
          vIslandCircleElementPropertiesChanged.CircleElementPropertiesChanged();
      }
    }
      private CircleElementProperties _CircleElementProperties{get;set;}
  }
}
