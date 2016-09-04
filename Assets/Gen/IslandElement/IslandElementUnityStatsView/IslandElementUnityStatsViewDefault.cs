namespace DarkIslands{
  public class IslandElementUnityStatsViewDefault: IIslandElementHydrationPointsChanged, IIslandElementMaxHydrationPointsChanged, IIslandElementLifePointsChanged, IIslandElementMaxLifePointsChanged, IIslandElementManaPointsChanged, IIslandElementMaxManaPointsChanged, IIslandElementIslandElementViewSettingsChanged, IIslandElementPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementUnityStatsViewFactory IslandElementUnityStatsViewFactory){
    }
    public virtual void HydrationPointsChanged(){}
    public virtual void MaxHydrationPointsChanged(){}
    public virtual void LifePointsChanged(){}
    public virtual void MaxLifePointsChanged(){}
    public virtual void ManaPointsChanged(){}
    public virtual void MaxManaPointsChanged(){}
    public virtual void IslandElementViewSettingsChanged(){}
    public virtual void PositionChanged(){}
  }
}
