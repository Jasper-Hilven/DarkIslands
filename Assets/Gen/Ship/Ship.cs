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
    public Vector3 Speed
    {
      get{
        return _Speed;
      }
      set
      {
        this._Speed= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.SpeedChanged();
      }
    }
      private Vector3 _Speed{get;set;}
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
