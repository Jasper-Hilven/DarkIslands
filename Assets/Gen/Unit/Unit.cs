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
    public bool hasLight
    {
      get{
        return _hasLight;
      }
      set
      {
        this._hasLight= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.hasLightChanged();
      }
    }
      private bool _hasLight{get;set;}
    public bool hasElementView
    {
      get{
        return _hasElementView;
      }
      set
      {
        this._hasElementView= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.hasElementViewChanged();
      }
    }
      private bool _hasElementView{get;set;}
    public ElementInfo ElementInfo
    {
      get{
        return _ElementInfo;
      }
      set
      {
        this._ElementInfo= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.ElementInfoChanged();
      }
    }
      private ElementInfo _ElementInfo{get;set;}
    public IWOContainerController WOContainerController
    {
      get{
        return _WOContainerController;
      }
      set
      {
        this._WOContainerController= value;
        foreach( var vUnitChanged in ChangeListeners)
          vUnitChanged.WOContainerControllerChanged();
      }
    }
      private IWOContainerController _WOContainerController{get;set;}
  }
}
