using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Unit
  {
  public List<IUnitChanged> ChangeListeners= new List<IUnitChanged>();
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public IElementType ElementType
    {
      get{
        return _ElementType;
      }
      set
      {
        this._ElementType= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.ElementTypeChanged();
      }
    }
      private IElementType _ElementType{get;set;}
    public Vector3 intendedGoalPosition
    {
      get{
        return _intendedGoalPosition;
      }
      set
      {
        this._intendedGoalPosition= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.intendedGoalPositionChanged();
      }
    }
      private Vector3 _intendedGoalPosition{get;set;}
    public bool intendedToMove
    {
      get{
        return _intendedToMove;
      }
      set
      {
        this._intendedToMove= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.intendedToMoveChanged();
      }
    }
      private bool _intendedToMove{get;set;}
    public float MaxSpeed
    {
      get{
        return _MaxSpeed;
      }
      set
      {
        this._MaxSpeed= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.MaxSpeedChanged();
      }
    }
      private float _MaxSpeed{get;set;}
  }
}
