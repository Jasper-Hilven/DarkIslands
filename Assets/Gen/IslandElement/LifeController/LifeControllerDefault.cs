namespace DarkIslands{
  public class LifeControllerDefault: IIslandElementChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, LifeControllerFactory LifeControllerFactory){
    }
    public virtual void LifePointsChanged(){}
    public virtual void InventoryChanged(){}
    public virtual void IslandPositionChanged(){}
    public virtual void RelativeToContainerPositionChanged(){}
    public virtual void PositionChanged(){}
    public virtual void IslandChanged(){}
    public virtual void IslandToEnterChanged(){}
    public virtual void CircleElementPropertiesChanged(){}
    public virtual void MaxSpeedChanged(){}
    public virtual void RelativeGoalPositionChanged(){}
    public virtual void HasRelativeGoalPositionChanged(){}
    public virtual void CurrentActionChanged(){}
    public virtual void CurrentCommandChanged(){}
    public virtual void hasLightChanged(){}
    public virtual void HarvestControllerChanged(){}
    public virtual void HarvestInfoChanged(){}
    public virtual void IsElementalColoredChanged(){}
    public virtual void hasElementalViewChanged(){}
    public virtual void ElementalInfoChanged(){}
    public virtual void ElementalTypeChanged(){}
    public virtual void ManaPointsChanged(){}
    public virtual void MaxManaPointsChanged(){}
    public virtual void CanUseManaChanged(){}
    public virtual void IsSpawnedChanged(){}
    public virtual void SpawnParentChanged(){}
    public virtual void IslandElementViewSettingsChanged(){}
  }
}
