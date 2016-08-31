namespace DarkIslands{
  public class IslandElementUnityViewDefault: IIslandElementIslandElementViewSettingsChanged, IIslandElementIsElementalColoredChanged, IIslandElementElementalTypeChanged, IIslandElementPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementUnityViewFactory IslandElementUnityViewFactory){
    }
    public virtual void IslandElementViewSettingsChanged(){}
    public virtual void IsElementalColoredChanged(){}
    public virtual void ElementalTypeChanged(){}
    public virtual void PositionChanged(){}
  }
}
