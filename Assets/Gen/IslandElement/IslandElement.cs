using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElement
  {
  public List<IIslandElementLifePointsChanged> ChangeLifePointsListeners= new List<IIslandElementLifePointsChanged>();
  public List<IIslandElementIsAliveChanged> ChangeIsAliveListeners= new List<IIslandElementIsAliveChanged>();
  public List<IIslandElementInventoryChanged> ChangeInventoryListeners= new List<IIslandElementInventoryChanged>();
  public List<IIslandElementHasInventoryChanged> ChangeHasInventoryListeners= new List<IIslandElementHasInventoryChanged>();
  public List<IIslandElementInventoryControllerChanged> ChangeInventoryControllerListeners= new List<IIslandElementInventoryControllerChanged>();
  public List<IIslandElementIslandPositionChanged> ChangeIslandPositionListeners= new List<IIslandElementIslandPositionChanged>();
  public List<IIslandElementRelativeToContainerPositionChanged> ChangeRelativeToContainerPositionListeners= new List<IIslandElementRelativeToContainerPositionChanged>();
  public List<IIslandElementPositionChanged> ChangePositionListeners= new List<IIslandElementPositionChanged>();
  public List<IIslandElementIslandChanged> ChangeIslandListeners= new List<IIslandElementIslandChanged>();
  public List<IIslandElementIslandToEnterChanged> ChangeIslandToEnterListeners= new List<IIslandElementIslandToEnterChanged>();
  public List<IIslandElementCircleElementPropertiesChanged> ChangeCircleElementPropertiesListeners= new List<IIslandElementCircleElementPropertiesChanged>();
  public List<IIslandElementMaxSpeedChanged> ChangeMaxSpeedListeners= new List<IIslandElementMaxSpeedChanged>();
  public List<IIslandElementRelativeGoalPositionChanged> ChangeRelativeGoalPositionListeners= new List<IIslandElementRelativeGoalPositionChanged>();
  public List<IIslandElementHasRelativeGoalPositionChanged> ChangeHasRelativeGoalPositionListeners= new List<IIslandElementHasRelativeGoalPositionChanged>();
  public List<IIslandElementCurrentCommandChanged> ChangeCurrentCommandListeners= new List<IIslandElementCurrentCommandChanged>();
  public List<IIslandElementCurrentActionChanged> ChangeCurrentActionListeners= new List<IIslandElementCurrentActionChanged>();
  public List<IIslandElementhasLightChanged> ChangehasLightListeners= new List<IIslandElementhasLightChanged>();
  public List<IIslandElementHarvestControllerChanged> ChangeHarvestControllerListeners= new List<IIslandElementHarvestControllerChanged>();
  public List<IIslandElementHarvestInfoChanged> ChangeHarvestInfoListeners= new List<IIslandElementHarvestInfoChanged>();
  public List<IIslandElementSizeChanged> ChangeSizeListeners= new List<IIslandElementSizeChanged>();
  public List<IIslandElementSizeControllerChanged> ChangeSizeControllerListeners= new List<IIslandElementSizeControllerChanged>();
  public List<IIslandElementIsElementalColoredChanged> ChangeIsElementalColoredListeners= new List<IIslandElementIsElementalColoredChanged>();
  public List<IIslandElementhasElementalViewChanged> ChangehasElementalViewListeners= new List<IIslandElementhasElementalViewChanged>();
  public List<IIslandElementElementalInfoChanged> ChangeElementalInfoListeners= new List<IIslandElementElementalInfoChanged>();
  public List<IIslandElementElementalTypeChanged> ChangeElementalTypeListeners= new List<IIslandElementElementalTypeChanged>();
  public List<IIslandElementManaPointsChanged> ChangeManaPointsListeners= new List<IIslandElementManaPointsChanged>();
  public List<IIslandElementMaxManaPointsChanged> ChangeMaxManaPointsListeners= new List<IIslandElementMaxManaPointsChanged>();
  public List<IIslandElementCanUseManaChanged> ChangeCanUseManaListeners= new List<IIslandElementCanUseManaChanged>();
  public List<IIslandElementIsSpawnedChanged> ChangeIsSpawnedListeners= new List<IIslandElementIsSpawnedChanged>();
  public List<IIslandElementSpawnParentChanged> ChangeSpawnParentListeners= new List<IIslandElementSpawnParentChanged>();
  public List<IIslandElementIslandElementViewSettingsChanged> ChangeIslandElementViewSettingsListeners= new List<IIslandElementIslandElementViewSettingsChanged>();
  public List<IIslandElementIsAnimatedChanged> ChangeIsAnimatedListeners= new List<IIslandElementIsAnimatedChanged>();
  public List<IIslandElementGivesHoverInformationChanged> ChangeGivesHoverInformationListeners= new List<IIslandElementGivesHoverInformationChanged>();
  public List<IIslandElementCanBeSelectedChanged> ChangeCanBeSelectedListeners= new List<IIslandElementCanBeSelectedChanged>();
    public int LifePoints
    {
      get{
        return _LifePoints;
      }
      set
      {
        this._LifePoints= value;
        foreach( var vIslandElementLifePointsChanged in ChangeLifePointsListeners)
          vIslandElementLifePointsChanged.LifePointsChanged();
      }
    }
      private int _LifePoints{get;set;}
    public bool IsAlive
    {
      get{
        return _IsAlive;
      }
      set
      {
        this._IsAlive= value;
        foreach( var vIslandElementIsAliveChanged in ChangeIsAliveListeners)
          vIslandElementIsAliveChanged.IsAliveChanged();
      }
    }
      private bool _IsAlive{get;set;}
    public Inventory Inventory
    {
      get{
        return _Inventory;
      }
      set
      {
        this._Inventory= value;
        foreach( var vIslandElementInventoryChanged in ChangeInventoryListeners)
          vIslandElementInventoryChanged.InventoryChanged();
      }
    }
      private Inventory _Inventory{get;set;}
    public bool HasInventory
    {
      get{
        return _HasInventory;
      }
      set
      {
        this._HasInventory= value;
        foreach( var vIslandElementHasInventoryChanged in ChangeHasInventoryListeners)
          vIslandElementHasInventoryChanged.HasInventoryChanged();
      }
    }
      private bool _HasInventory{get;set;}
    public InventoryController InventoryController
    {
      get{
        return _InventoryController;
      }
      set
      {
        this._InventoryController= value;
        foreach( var vIslandElementInventoryControllerChanged in ChangeInventoryControllerListeners)
          vIslandElementInventoryControllerChanged.InventoryControllerChanged();
      }
    }
      private InventoryController _InventoryController{get;set;}
    public Vector3 IslandPosition
    {
      get{
        return _IslandPosition;
      }
      set
      {
        this._IslandPosition= value;
        foreach( var vIslandElementIslandPositionChanged in ChangeIslandPositionListeners)
          vIslandElementIslandPositionChanged.IslandPositionChanged();
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
        foreach( var vIslandElementRelativeToContainerPositionChanged in ChangeRelativeToContainerPositionListeners)
          vIslandElementRelativeToContainerPositionChanged.RelativeToContainerPositionChanged();
      }
    }
      private Vector3 _RelativeToContainerPosition{get;set;}
    public Vector3 Position
    {
      get{
        return _Position;
      }
      set
      {
        this._Position= value;
        foreach( var vIslandElementPositionChanged in ChangePositionListeners)
          vIslandElementPositionChanged.PositionChanged();
      }
    }
      private Vector3 _Position{get;set;}
    public Island Island
    {
      get{
        return _Island;
      }
      set
      {
        this._Island= value;
        foreach( var vIslandElementIslandChanged in ChangeIslandListeners)
          vIslandElementIslandChanged.IslandChanged();
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
        foreach( var vIslandElementIslandToEnterChanged in ChangeIslandToEnterListeners)
          vIslandElementIslandToEnterChanged.IslandToEnterChanged();
      }
    }
      private Island _IslandToEnter{get;set;}
    public CircleElementProperties CircleElementProperties
    {
      get{
        return _CircleElementProperties;
      }
      set
      {
        this._CircleElementProperties= value;
        foreach( var vIslandElementCircleElementPropertiesChanged in ChangeCircleElementPropertiesListeners)
          vIslandElementCircleElementPropertiesChanged.CircleElementPropertiesChanged();
      }
    }
      private CircleElementProperties _CircleElementProperties{get;set;}
    public float MaxSpeed
    {
      get{
        return _MaxSpeed;
      }
      set
      {
        this._MaxSpeed= value;
        foreach( var vIslandElementMaxSpeedChanged in ChangeMaxSpeedListeners)
          vIslandElementMaxSpeedChanged.MaxSpeedChanged();
      }
    }
      private float _MaxSpeed{get;set;}
    public Vector3 RelativeGoalPosition
    {
      get{
        return _RelativeGoalPosition;
      }
      set
      {
        this._RelativeGoalPosition= value;
        foreach( var vIslandElementRelativeGoalPositionChanged in ChangeRelativeGoalPositionListeners)
          vIslandElementRelativeGoalPositionChanged.RelativeGoalPositionChanged();
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
        foreach( var vIslandElementHasRelativeGoalPositionChanged in ChangeHasRelativeGoalPositionListeners)
          vIslandElementHasRelativeGoalPositionChanged.HasRelativeGoalPositionChanged();
      }
    }
      private bool _HasRelativeGoalPosition{get;set;}
    public IIslandElementCommand CurrentCommand
    {
      get{
        return _CurrentCommand;
      }
      set
      {
        this._CurrentCommand= value;
        foreach( var vIslandElementCurrentCommandChanged in ChangeCurrentCommandListeners)
          vIslandElementCurrentCommandChanged.CurrentCommandChanged();
      }
    }
      private IIslandElementCommand _CurrentCommand{get;set;}
    public IIslandElementAction CurrentAction
    {
      get{
        return _CurrentAction;
      }
      set
      {
        this._CurrentAction= value;
        foreach( var vIslandElementCurrentActionChanged in ChangeCurrentActionListeners)
          vIslandElementCurrentActionChanged.CurrentActionChanged();
      }
    }
      private IIslandElementAction _CurrentAction{get;set;}
    public bool hasLight
    {
      get{
        return _hasLight;
      }
      set
      {
        this._hasLight= value;
        foreach( var vIslandElementhasLightChanged in ChangehasLightListeners)
          vIslandElementhasLightChanged.hasLightChanged();
      }
    }
      private bool _hasLight{get;set;}
    public HarvestController HarvestController
    {
      get{
        return _HarvestController;
      }
      set
      {
        this._HarvestController= value;
        foreach( var vIslandElementHarvestControllerChanged in ChangeHarvestControllerListeners)
          vIslandElementHarvestControllerChanged.HarvestControllerChanged();
      }
    }
      private HarvestController _HarvestController{get;set;}
    public HarvestInfo HarvestInfo
    {
      get{
        return _HarvestInfo;
      }
      set
      {
        this._HarvestInfo= value;
        foreach( var vIslandElementHarvestInfoChanged in ChangeHarvestInfoListeners)
          vIslandElementHarvestInfoChanged.HarvestInfoChanged();
      }
    }
      private HarvestInfo _HarvestInfo{get;set;}
    public float Size
    {
      get{
        return _Size;
      }
      set
      {
        this._Size= value;
        foreach( var vIslandElementSizeChanged in ChangeSizeListeners)
          vIslandElementSizeChanged.SizeChanged();
      }
    }
      private float _Size{get;set;}
    public ISizeController SizeController
    {
      get{
        return _SizeController;
      }
      set
      {
        this._SizeController= value;
        foreach( var vIslandElementSizeControllerChanged in ChangeSizeControllerListeners)
          vIslandElementSizeControllerChanged.SizeControllerChanged();
      }
    }
      private ISizeController _SizeController{get;set;}
    public bool IsElementalColored
    {
      get{
        return _IsElementalColored;
      }
      set
      {
        this._IsElementalColored= value;
        foreach( var vIslandElementIsElementalColoredChanged in ChangeIsElementalColoredListeners)
          vIslandElementIsElementalColoredChanged.IsElementalColoredChanged();
      }
    }
      private bool _IsElementalColored{get;set;}
    public bool hasElementalView
    {
      get{
        return _hasElementalView;
      }
      set
      {
        this._hasElementalView= value;
        foreach( var vIslandElementhasElementalViewChanged in ChangehasElementalViewListeners)
          vIslandElementhasElementalViewChanged.hasElementalViewChanged();
      }
    }
      private bool _hasElementalView{get;set;}
    public ElementalInfo ElementalInfo
    {
      get{
        return _ElementalInfo;
      }
      set
      {
        this._ElementalInfo= value;
        foreach( var vIslandElementElementalInfoChanged in ChangeElementalInfoListeners)
          vIslandElementElementalInfoChanged.ElementalInfoChanged();
      }
    }
      private ElementalInfo _ElementalInfo{get;set;}
    public IElementalType ElementalType
    {
      get{
        return _ElementalType;
      }
      set
      {
        this._ElementalType= value;
        foreach( var vIslandElementElementalTypeChanged in ChangeElementalTypeListeners)
          vIslandElementElementalTypeChanged.ElementalTypeChanged();
      }
    }
      private IElementalType _ElementalType{get;set;}
    public int ManaPoints
    {
      get{
        return _ManaPoints;
      }
      set
      {
        this._ManaPoints= value;
        foreach( var vIslandElementManaPointsChanged in ChangeManaPointsListeners)
          vIslandElementManaPointsChanged.ManaPointsChanged();
      }
    }
      private int _ManaPoints{get;set;}
    public int MaxManaPoints
    {
      get{
        return _MaxManaPoints;
      }
      set
      {
        this._MaxManaPoints= value;
        foreach( var vIslandElementMaxManaPointsChanged in ChangeMaxManaPointsListeners)
          vIslandElementMaxManaPointsChanged.MaxManaPointsChanged();
      }
    }
      private int _MaxManaPoints{get;set;}
    public bool CanUseMana
    {
      get{
        return _CanUseMana;
      }
      set
      {
        this._CanUseMana= value;
        foreach( var vIslandElementCanUseManaChanged in ChangeCanUseManaListeners)
          vIslandElementCanUseManaChanged.CanUseManaChanged();
      }
    }
      private bool _CanUseMana{get;set;}
    public bool IsSpawned
    {
      get{
        return _IsSpawned;
      }
      set
      {
        this._IsSpawned= value;
        foreach( var vIslandElementIsSpawnedChanged in ChangeIsSpawnedListeners)
          vIslandElementIsSpawnedChanged.IsSpawnedChanged();
      }
    }
      private bool _IsSpawned{get;set;}
    public IslandElement SpawnParent
    {
      get{
        return _SpawnParent;
      }
      set
      {
        this._SpawnParent= value;
        foreach( var vIslandElementSpawnParentChanged in ChangeSpawnParentListeners)
          vIslandElementSpawnParentChanged.SpawnParentChanged();
      }
    }
      private IslandElement _SpawnParent{get;set;}
    public IslandElementViewSettings IslandElementViewSettings
    {
      get{
        return _IslandElementViewSettings;
      }
      set
      {
        this._IslandElementViewSettings= value;
        foreach( var vIslandElementIslandElementViewSettingsChanged in ChangeIslandElementViewSettingsListeners)
          vIslandElementIslandElementViewSettingsChanged.IslandElementViewSettingsChanged();
      }
    }
      private IslandElementViewSettings _IslandElementViewSettings{get;set;}
    public bool IsAnimated
    {
      get{
        return _IsAnimated;
      }
      set
      {
        this._IsAnimated= value;
        foreach( var vIslandElementIsAnimatedChanged in ChangeIsAnimatedListeners)
          vIslandElementIsAnimatedChanged.IsAnimatedChanged();
      }
    }
      private bool _IsAnimated{get;set;}
    public bool GivesHoverInformation
    {
      get{
        return _GivesHoverInformation;
      }
      set
      {
        this._GivesHoverInformation= value;
        foreach( var vIslandElementGivesHoverInformationChanged in ChangeGivesHoverInformationListeners)
          vIslandElementGivesHoverInformationChanged.GivesHoverInformationChanged();
      }
    }
      private bool _GivesHoverInformation{get;set;}
    public bool CanBeSelected
    {
      get{
        return _CanBeSelected;
      }
      set
      {
        this._CanBeSelected= value;
        foreach( var vIslandElementCanBeSelectedChanged in ChangeCanBeSelectedListeners)
          vIslandElementCanBeSelectedChanged.CanBeSelectedChanged();
      }
    }
      private bool _CanBeSelected{get;set;}
  }
}
