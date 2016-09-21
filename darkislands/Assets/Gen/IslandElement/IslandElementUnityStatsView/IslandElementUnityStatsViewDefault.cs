namespace DarkIslands{
  public class IslandElementUnityStatsViewDefault: IIslandElementPositionChanged, IIslandElementLifePointsChanged, IIslandElementMaxLifePointsChanged, IIslandElementHydrationPointsChanged, IIslandElementMaxHydrationPointsChanged, IIslandElementManaPointsChanged, IIslandElementMaxManaPointsChanged, IIslandElementIslandElementViewSettingsChanged, IIslandElementSpawnTimeToLifeChanged, IIslandElementMaxSpawnTimeToLifeChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementUnityStatsViewFactory IslandElementUnityStatsViewFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void LifePointsChanged(){}
    public virtual void MaxLifePointsChanged(){}
    public virtual void HydrationPointsChanged(){}
    public virtual void MaxHydrationPointsChanged(){}
    public virtual void ManaPointsChanged(){}
    public virtual void MaxManaPointsChanged(){}
    public virtual void IslandElementViewSettingsChanged(){}
    public virtual void SpawnTimeToLifeChanged(){}
    public virtual void MaxSpawnTimeToLifeChanged(){}
  }
}
