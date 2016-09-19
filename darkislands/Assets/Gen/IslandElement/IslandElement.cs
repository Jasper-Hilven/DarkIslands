using UnityEngine;
using System.Collections.Generic;
namespace DarkIslands
{
  public partial class IslandElement
  {
  public List<IIslandElementFactoryChanged> ChangeFactoryListeners= new List<IIslandElementFactoryChanged>();
  public List<IIslandElementInventoryChanged> ChangeInventoryListeners= new List<IIslandElementInventoryChanged>();
  public List<IIslandElementHasInventoryChanged> ChangeHasInventoryListeners= new List<IIslandElementHasInventoryChanged>();
  public List<IIslandElementInventoryControllerChanged> ChangeInventoryControllerListeners= new List<IIslandElementInventoryControllerChanged>();
  public List<IIslandElementIslandPositionChanged> ChangeIslandPositionListeners= new List<IIslandElementIslandPositionChanged>();
  public List<IIslandElementRelativeToContainerPositionChanged> ChangeRelativeToContainerPositionListeners= new List<IIslandElementRelativeToContainerPositionChanged>();
  public List<IIslandElementPositionChanged> ChangePositionListeners= new List<IIslandElementPositionChanged>();
  public List<IIslandElementIslandChanged> ChangeIslandListeners= new List<IIslandElementIslandChanged>();
  public List<IIslandElementIslandToEnterChanged> ChangeIslandToEnterListeners= new List<IIslandElementIslandToEnterChanged>();
  public List<IIslandElementCircleElementPropertiesChanged> ChangeCircleElementPropertiesListeners= new List<IIslandElementCircleElementPropertiesChanged>();
  public List<IIslandElementIslandManagerChanged> ChangeIslandManagerListeners= new List<IIslandElementIslandManagerChanged>();
  public List<IIslandElementMaxSpeedChanged> ChangeMaxSpeedListeners= new List<IIslandElementMaxSpeedChanged>();
  public List<IIslandElementMovementControllerChanged> ChangeMovementControllerListeners= new List<IIslandElementMovementControllerChanged>();
  public List<IIslandElementRelativeGoalPositionChanged> ChangeRelativeGoalPositionListeners= new List<IIslandElementRelativeGoalPositionChanged>();
  public List<IIslandElementHasRelativeGoalPositionChanged> ChangeHasRelativeGoalPositionListeners= new List<IIslandElementHasRelativeGoalPositionChanged>();
  public List<IIslandElementCurrentCommandChanged> ChangeCurrentCommandListeners= new List<IIslandElementCurrentCommandChanged>();
  public List<IIslandElementCurrentActionChanged> ChangeCurrentActionListeners= new List<IIslandElementCurrentActionChanged>();
  public List<IIslandElementCurrentLifeActionChanged> ChangeCurrentLifeActionListeners= new List<IIslandElementCurrentLifeActionChanged>();
  public List<IIslandElementActionHandlerChanged> ChangeActionHandlerListeners= new List<IIslandElementActionHandlerChanged>();
  public List<IIslandElementhasLightChanged> ChangehasLightListeners= new List<IIslandElementhasLightChanged>();
  public List<IIslandElementHarvestControllerChanged> ChangeHarvestControllerListeners= new List<IIslandElementHarvestControllerChanged>();
  public List<IIslandElementHarvestInfoChanged> ChangeHarvestInfoListeners= new List<IIslandElementHarvestInfoChanged>();
  public List<IIslandElementSizeChanged> ChangeSizeListeners= new List<IIslandElementSizeChanged>();
  public List<IIslandElementSizeControllerChanged> ChangeSizeControllerListeners= new List<IIslandElementSizeControllerChanged>();
  public List<IIslandElementDropOffControllerChanged> ChangeDropOffControllerListeners= new List<IIslandElementDropOffControllerChanged>();
  public List<IIslandElementIsElementalColoredChanged> ChangeIsElementalColoredListeners= new List<IIslandElementIsElementalColoredChanged>();
  public List<IIslandElementhasElementalViewChanged> ChangehasElementalViewListeners= new List<IIslandElementhasElementalViewChanged>();
  public List<IIslandElementElementalInfoChanged> ChangeElementalInfoListeners= new List<IIslandElementElementalInfoChanged>();
  public List<IIslandElementElementalTypeChanged> ChangeElementalTypeListeners= new List<IIslandElementElementalTypeChanged>();
  public List<IIslandElementElementalControllerChanged> ChangeElementalControllerListeners= new List<IIslandElementElementalControllerChanged>();
  public List<IIslandElementManaPointsChanged> ChangeManaPointsListeners= new List<IIslandElementManaPointsChanged>();
  public List<IIslandElementMaxManaPointsChanged> ChangeMaxManaPointsListeners= new List<IIslandElementMaxManaPointsChanged>();
  public List<IIslandElementCanUseManaChanged> ChangeCanUseManaListeners= new List<IIslandElementCanUseManaChanged>();
  public List<IIslandElementMagicControllerChanged> ChangeMagicControllerListeners= new List<IIslandElementMagicControllerChanged>();
  public List<IIslandElementCanDehydrateChanged> ChangeCanDehydrateListeners= new List<IIslandElementCanDehydrateChanged>();
  public List<IIslandElementHydrationPointsChanged> ChangeHydrationPointsListeners= new List<IIslandElementHydrationPointsChanged>();
  public List<IIslandElementMaxHydrationPointsChanged> ChangeMaxHydrationPointsListeners= new List<IIslandElementMaxHydrationPointsChanged>();
  public List<IIslandElementDehydrationRateChanged> ChangeDehydrationRateListeners= new List<IIslandElementDehydrationRateChanged>();
  public List<IIslandElementHydrationControllerChanged> ChangeHydrationControllerListeners= new List<IIslandElementHydrationControllerChanged>();
  public List<IIslandElementLifePointsChanged> ChangeLifePointsListeners= new List<IIslandElementLifePointsChanged>();
  public List<IIslandElementLifeControllerChanged> ChangeLifeControllerListeners= new List<IIslandElementLifeControllerChanged>();
  public List<IIslandElementMaxLifePointsChanged> ChangeMaxLifePointsListeners= new List<IIslandElementMaxLifePointsChanged>();
  public List<IIslandElementIsAliveChanged> ChangeIsAliveListeners= new List<IIslandElementIsAliveChanged>();
  public List<IIslandElementIsSpawnedChanged> ChangeIsSpawnedListeners= new List<IIslandElementIsSpawnedChanged>();
  public List<IIslandElementSpawnParentChanged> ChangeSpawnParentListeners= new List<IIslandElementSpawnParentChanged>();
  public List<IIslandElementSpawnTimeToLifeChanged> ChangeSpawnTimeToLifeListeners= new List<IIslandElementSpawnTimeToLifeChanged>();
  public List<IIslandElementSpawnControllerChanged> ChangeSpawnControllerListeners= new List<IIslandElementSpawnControllerChanged>();
  public List<IIslandElementIslandElementViewSettingsChanged> ChangeIslandElementViewSettingsListeners= new List<IIslandElementIslandElementViewSettingsChanged>();
  public List<IIslandElementIsAnimatedChanged> ChangeIsAnimatedListeners= new List<IIslandElementIsAnimatedChanged>();
  public List<IIslandElementGivesHoverInformationChanged> ChangeGivesHoverInformationListeners= new List<IIslandElementGivesHoverInformationChanged>();
  public List<IIslandElementCanBeSelectedChanged> ChangeCanBeSelectedListeners= new List<IIslandElementCanBeSelectedChanged>();
  public List<IIslandElementFightingControllerChanged> ChangeFightingControllerListeners= new List<IIslandElementFightingControllerChanged>();
  public List<IIslandElementTeamControllerChanged> ChangeTeamControllerListeners= new List<IIslandElementTeamControllerChanged>();
    public IslandElementFactory Factory
    {
      get{
        return _Factory;
      }
      set
      {
        this._Factory= value;
        foreach( var vIslandElementFactoryChanged in ChangeFactoryListeners)
          vIslandElementFactoryChanged.FactoryChanged();
      }
    }
      private IslandElementFactory _Factory{get;set;}
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
    public IslandElementContainerManager IslandManager
    {
      get{
        return _IslandManager;
      }
      set
      {
        this._IslandManager= value;
        foreach( var vIslandElementIslandManagerChanged in ChangeIslandManagerListeners)
          vIslandElementIslandManagerChanged.IslandManagerChanged();
      }
    }
      private IslandElementContainerManager _IslandManager{get;set;}
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
    public IslandElementMovementController MovementController
    {
      get{
        return _MovementController;
      }
      set
      {
        this._MovementController= value;
        foreach( var vIslandElementMovementControllerChanged in ChangeMovementControllerListeners)
          vIslandElementMovementControllerChanged.MovementControllerChanged();
      }
    }
      private IslandElementMovementController _MovementController{get;set;}
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
    public IIslandElementAction CurrentLifeAction
    {
      get{
        return _CurrentLifeAction;
      }
      set
      {
        this._CurrentLifeAction= value;
        foreach( var vIslandElementCurrentLifeActionChanged in ChangeCurrentLifeActionListeners)
          vIslandElementCurrentLifeActionChanged.CurrentLifeActionChanged();
      }
    }
      private IIslandElementAction _CurrentLifeAction{get;set;}
    public IslandElementActionHandler ActionHandler
    {
      get{
        return _ActionHandler;
      }
      set
      {
        this._ActionHandler= value;
        foreach( var vIslandElementActionHandlerChanged in ChangeActionHandlerListeners)
          vIslandElementActionHandlerChanged.ActionHandlerChanged();
      }
    }
      private IslandElementActionHandler _ActionHandler{get;set;}
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
    public IslandElementDropOffController DropOffController
    {
      get{
        return _DropOffController;
      }
      set
      {
        this._DropOffController= value;
        foreach( var vIslandElementDropOffControllerChanged in ChangeDropOffControllerListeners)
          vIslandElementDropOffControllerChanged.DropOffControllerChanged();
      }
    }
      private IslandElementDropOffController _DropOffController{get;set;}
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
    public IslandElementElementalController ElementalController
    {
      get{
        return _ElementalController;
      }
      set
      {
        this._ElementalController= value;
        foreach( var vIslandElementElementalControllerChanged in ChangeElementalControllerListeners)
          vIslandElementElementalControllerChanged.ElementalControllerChanged();
      }
    }
      private IslandElementElementalController _ElementalController{get;set;}
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
    public IslandElementMagicController MagicController
    {
      get{
        return _MagicController;
      }
      set
      {
        this._MagicController= value;
        foreach( var vIslandElementMagicControllerChanged in ChangeMagicControllerListeners)
          vIslandElementMagicControllerChanged.MagicControllerChanged();
      }
    }
      private IslandElementMagicController _MagicController{get;set;}
    public bool CanDehydrate
    {
      get{
        return _CanDehydrate;
      }
      set
      {
        this._CanDehydrate= value;
        foreach( var vIslandElementCanDehydrateChanged in ChangeCanDehydrateListeners)
          vIslandElementCanDehydrateChanged.CanDehydrateChanged();
      }
    }
      private bool _CanDehydrate{get;set;}
    public int HydrationPoints
    {
      get{
        return _HydrationPoints;
      }
      set
      {
        this._HydrationPoints= value;
        foreach( var vIslandElementHydrationPointsChanged in ChangeHydrationPointsListeners)
          vIslandElementHydrationPointsChanged.HydrationPointsChanged();
      }
    }
      private int _HydrationPoints{get;set;}
    public int MaxHydrationPoints
    {
      get{
        return _MaxHydrationPoints;
      }
      set
      {
        this._MaxHydrationPoints= value;
        foreach( var vIslandElementMaxHydrationPointsChanged in ChangeMaxHydrationPointsListeners)
          vIslandElementMaxHydrationPointsChanged.MaxHydrationPointsChanged();
      }
    }
      private int _MaxHydrationPoints{get;set;}
    public int DehydrationRate
    {
      get{
        return _DehydrationRate;
      }
      set
      {
        this._DehydrationRate= value;
        foreach( var vIslandElementDehydrationRateChanged in ChangeDehydrationRateListeners)
          vIslandElementDehydrationRateChanged.DehydrationRateChanged();
      }
    }
      private int _DehydrationRate{get;set;}
    public IslandElementHydrationController HydrationController
    {
      get{
        return _HydrationController;
      }
      set
      {
        this._HydrationController= value;
        foreach( var vIslandElementHydrationControllerChanged in ChangeHydrationControllerListeners)
          vIslandElementHydrationControllerChanged.HydrationControllerChanged();
      }
    }
      private IslandElementHydrationController _HydrationController{get;set;}
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
    public IslandElementLifeController LifeController
    {
      get{
        return _LifeController;
      }
      set
      {
        this._LifeController= value;
        foreach( var vIslandElementLifeControllerChanged in ChangeLifeControllerListeners)
          vIslandElementLifeControllerChanged.LifeControllerChanged();
      }
    }
      private IslandElementLifeController _LifeController{get;set;}
    public int MaxLifePoints
    {
      get{
        return _MaxLifePoints;
      }
      set
      {
        this._MaxLifePoints= value;
        foreach( var vIslandElementMaxLifePointsChanged in ChangeMaxLifePointsListeners)
          vIslandElementMaxLifePointsChanged.MaxLifePointsChanged();
      }
    }
      private int _MaxLifePoints{get;set;}
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
    public float SpawnTimeToLife
    {
      get{
        return _SpawnTimeToLife;
      }
      set
      {
        this._SpawnTimeToLife= value;
        foreach( var vIslandElementSpawnTimeToLifeChanged in ChangeSpawnTimeToLifeListeners)
          vIslandElementSpawnTimeToLifeChanged.SpawnTimeToLifeChanged();
      }
    }
      private float _SpawnTimeToLife{get;set;}
    public IslandElementSpawnController SpawnController
    {
      get{
        return _SpawnController;
      }
      set
      {
        this._SpawnController= value;
        foreach( var vIslandElementSpawnControllerChanged in ChangeSpawnControllerListeners)
          vIslandElementSpawnControllerChanged.SpawnControllerChanged();
      }
    }
      private IslandElementSpawnController _SpawnController{get;set;}
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
    public IslandElementFightingController FightingController
    {
      get{
        return _FightingController;
      }
      set
      {
        this._FightingController= value;
        foreach( var vIslandElementFightingControllerChanged in ChangeFightingControllerListeners)
          vIslandElementFightingControllerChanged.FightingControllerChanged();
      }
    }
      private IslandElementFightingController _FightingController{get;set;}
    public IslandElementTeamController TeamController
    {
      get{
        return _TeamController;
      }
      set
      {
        this._TeamController= value;
        foreach( var vIslandElementTeamControllerChanged in ChangeTeamControllerListeners)
          vIslandElementTeamControllerChanged.TeamControllerChanged();
      }
    }
      private IslandElementTeamController _TeamController{get;set;}
  }
}
