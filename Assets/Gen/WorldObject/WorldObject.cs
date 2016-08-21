using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class WorldObject
  {
  public List<IWorldObjectChanged> ChangeListeners= new List<IWorldObjectChanged>();
    public string Name
    {
      get{
        return _Name;
      }
      set
      {
        this._Name= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.NameChanged();
      }
    }
      private string _Name{get;set;}
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public WOHarvestController HarvestController
    {
      get{
        return _HarvestController;
      }
      set
      {
        this._HarvestController= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.HarvestControllerChanged();
      }
    }
      private WOHarvestController _HarvestController{get;set;}
    public WorldObjectType Type
    {
      get{
        return _Type;
      }
      set
      {
        this._Type= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.TypeChanged();
      }
    }
      private WorldObjectType _Type{get;set;}
    public Vector3 RelativePosition
    {
      get{
        return _RelativePosition;
      }
      set
      {
        this._RelativePosition= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.RelativePositionChanged();
      }
    }
      private Vector3 _RelativePosition{get;set;}
    public Vector3 ContainerPosition
    {
      get{
        return _ContainerPosition;
      }
      set
      {
        this._ContainerPosition= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.ContainerPositionChanged();
      }
    }
      private Vector3 _ContainerPosition{get;set;}
    public IWOContainer Container
    {
      get{
        return _Container;
      }
      set
      {
        this._Container= value;
        foreach( var vWorldObjectChanged in ChangeListeners)
          vWorldObjectChanged.ContainerChanged();
      }
    }
      private IWOContainer _Container{get;set;}
  }
}
