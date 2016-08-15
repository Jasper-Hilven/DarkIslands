using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class Unit
  {
  public List<IUnitChanged> ChangeListeners= new List<IUnitChanged>();
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
    public Vector3 RelativeGoalPosition
    {
      get{
        return _RelativeGoalPosition;
      }
      set
      {
        this._RelativeGoalPosition= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.RelativeGoalPositionChanged();
      }
    }
      private Vector3 _RelativeGoalPosition{get;set;}
    public bool HasRelativeGoalPosition
    {
      get{
        return _HasRelativeGoalPosition;
      }
      set
      {
        this._HasRelativeGoalPosition= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.HasRelativeGoalPositionChanged();
      }
    }
      private bool _HasRelativeGoalPosition{get;set;}
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
    public Vector3 ContainerPosition
    {
      get{
        return _ContainerPosition;
      }
      set
      {
        this._ContainerPosition= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.ContainerPositionChanged();
      }
    }
      private Vector3 _ContainerPosition{get;set;}
    public Vector3 RelativeToContainerPosition
    {
      get{
        return _RelativeToContainerPosition;
      }
      set
      {
        this._RelativeToContainerPosition= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.RelativeToContainerPositionChanged();
      }
    }
      private Vector3 _RelativeToContainerPosition{get;set;}
    public IUnitContainer Container
    {
      get{
        return _Container;
      }
      set
      {
        this._Container= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.ContainerChanged();
      }
    }
      private IUnitContainer _Container{get;set;}
    public IUnitContainer ContainerToEnter
    {
      get{
        return _ContainerToEnter;
      }
      set
      {
        this._ContainerToEnter= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.ContainerToEnterChanged();
      }
    }
      private IUnitContainer _ContainerToEnter{get;set;}
    public IUnitAction CurrentAction
    {
      get{
        return _CurrentAction;
      }
      set
      {
        this._CurrentAction= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.CurrentActionChanged();
      }
    }
      private IUnitAction _CurrentAction{get;set;}
    public IUnitCommand CurrentCommand
    {
      get{
        return _CurrentCommand;
      }
      set
      {
        this._CurrentCommand= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.CurrentCommandChanged();
      }
    }
      private IUnitCommand _CurrentCommand{get;set;}
  }
}
