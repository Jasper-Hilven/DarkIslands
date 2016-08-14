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
    public Vector3 IntendedDirection
    {
      get{
        return _IntendedDirection;
      }
      set
      {
        this._IntendedDirection= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.IntendedDirectionChanged();
      }
    }
      private Vector3 _IntendedDirection{get;set;}
    public bool Initialized
    {
      get{
        return _Initialized;
      }
      set
      {
        this._Initialized= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.InitializedChanged();
      }
    }
      private bool _Initialized{get;set;}
    public bool Alive
    {
      get{
        return _Alive;
      }
      set
      {
        this._Alive= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.AliveChanged();
      }
    }
      private bool _Alive{get;set;}
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
    public int Team
    {
      get{
        return _Team;
      }
      set
      {
        this._Team= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.TeamChanged();
      }
    }
      private int _Team{get;set;}
    public int ElementType
    {
      get{
        return _ElementType;
      }
      set
      {
        this._ElementType= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.ElementTypeChanged();
      }
    }
      private int _ElementType{get;set;}
    public string CurrentAction
    {
      get{
        return _CurrentAction;
      }
      set
      {
        this._CurrentAction= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.CurrentActionChanged();
      }
    }
      private string _CurrentAction{get;set;}
    public string NextActions
    {
      get{
        return _NextActions;
      }
      set
      {
        this._NextActions= value;
        foreach( var vShipChanged in ChangeListeners)
          vShipChanged.NextActionsChanged();
      }
    }
      private string _NextActions{get;set;}
  }
}
