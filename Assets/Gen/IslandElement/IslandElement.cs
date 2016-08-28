using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElement
  {
  public List<IIslandElementChanged> ChangeListeners= new List<IIslandElementChanged>();
    public IElementalType ElementalType
    {
      get{
        return _ElementalType;
      }
      set
      {
        this._ElementalType= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.ElementalTypeChanged();
      }
    }
      private IElementalType _ElementalType{get;set;}
    public Vector3 RelativeGoalPosition
    {
      get{
        return _RelativeGoalPosition;
      }
      set
      {
        this._RelativeGoalPosition= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.RelativeGoalPositionChanged();
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
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.HasRelativeGoalPositionChanged();
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
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.MaxSpeedChanged();
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
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public Vector3 IslandPosition
    {
      get{
        return _IslandPosition;
      }
      set
      {
        this._IslandPosition= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.IslandPositionChanged();
      }
    }
      private Vector3 _IslandPosition{get;set;}
    public Vector3 RelativeToContainerPosition
    {
      get{
        return _RelativeToContainerPosition;
      }
      set
      {
        this._RelativeToContainerPosition= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.RelativeToContainerPositionChanged();
      }
    }
      private Vector3 _RelativeToContainerPosition{get;set;}
    public Island Island
    {
      get{
        return _Island;
      }
      set
      {
        this._Island= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.IslandChanged();
      }
    }
      private Island _Island{get;set;}
    public Island IslandToEnter
    {
      get{
        return _IslandToEnter;
      }
      set
      {
        this._IslandToEnter= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.IslandToEnterChanged();
      }
    }
      private Island _IslandToEnter{get;set;}
    public IIslandElementAction CurrentAction
    {
      get{
        return _CurrentAction;
      }
      set
      {
        this._CurrentAction= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.CurrentActionChanged();
      }
    }
      private IIslandElementAction _CurrentAction{get;set;}
    public IIslandElementCommand CurrentCommand
    {
      get{
        return _CurrentCommand;
      }
      set
      {
        this._CurrentCommand= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.CurrentCommandChanged();
      }
    }
      private IIslandElementCommand _CurrentCommand{get;set;}
    public bool hasLight
    {
      get{
        return _hasLight;
      }
      set
      {
        this._hasLight= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.hasLightChanged();
      }
    }
      private bool _hasLight{get;set;}
    public IslandElementViewSettings IslandElementViewSettings
    {
      get{
        return _IslandElementViewSettings;
      }
      set
      {
        this._IslandElementViewSettings= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.IslandElementViewSettingsChanged();
      }
    }
      private IslandElementViewSettings _IslandElementViewSettings{get;set;}
    public bool hasElementalView
    {
      get{
        return _hasElementalView;
      }
      set
      {
        this._hasElementalView= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.hasElementalViewChanged();
      }
    }
      private bool _hasElementalView{get;set;}
    public bool IsElementalColored
    {
      get{
        return _IsElementalColored;
      }
      set
      {
        this._IsElementalColored= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.IsElementalColoredChanged();
      }
    }
      private bool _IsElementalColored{get;set;}
    public ElementalInfo ElementalInfo
    {
      get{
        return _ElementalInfo;
      }
      set
      {
        this._ElementalInfo= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.ElementalInfoChanged();
      }
    }
      private ElementalInfo _ElementalInfo{get;set;}
    public HarvestController HarvestController
    {
      get{
        return _HarvestController;
      }
      set
      {
        this._HarvestController= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.HarvestControllerChanged();
      }
    }
      private HarvestController _HarvestController{get;set;}
    public CircleElementProperties CircleElementProperties
    {
      get{
        return _CircleElementProperties;
      }
      set
      {
        this._CircleElementProperties= value;
        foreach( var vIslandElementChanged in ChangeListeners)
          vIslandElementChanged.CircleElementPropertiesChanged();
      }
    }
      private CircleElementProperties _CircleElementProperties{get;set;}
  }
}
