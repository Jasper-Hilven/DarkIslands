using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Ship
  {
  public List<IShipChanged> ChangeListeners= new List<IShipChanged>();
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public Vector3 GoalPosition
    {
      get{
        return _GoalPosition;
      }
      set
      {
        this._GoalPosition= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.GoalPositionChanged();
      }
    }
      private Vector3 _GoalPosition{get;set;}
    public bool HasGoalPosition
    {
      get{
        return _HasGoalPosition;
      }
      set
      {
        this._HasGoalPosition= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.HasGoalPositionChanged();
      }
    }
      private bool _HasGoalPosition{get;set;}
    public float MaxSpeed
    {
      get{
        return _MaxSpeed;
      }
      set
      {
        this._MaxSpeed= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.MaxSpeedChanged();
      }
    }
      private float _MaxSpeed{get;set;}
    public int LifePoints
    {
      get{
        return _LifePoints;
      }
      set
      {
        this._LifePoints= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.LifePointsChanged();
      }
    }
      private int _LifePoints{get;set;}
    public List<Item> Items
    {
      get{
        return _Items;
      }
      set
      {
        this._Items= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.ItemsChanged();
      }
    }
      private List<Item> _Items{get;set;}
    public UnitContainerController UnitContainerController
    {
      get{
        return _UnitContainerController;
      }
      set
      {
        this._UnitContainerController= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.UnitContainerControllerChanged();
      }
    }
      private UnitContainerController _UnitContainerController{get;set;}
  }
}
