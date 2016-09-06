namespace DarkIslands{
  public class IslandElementContainerManagerDefault: IIslandElementIslandPositionChanged, IIslandElementRelativeToContainerPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementContainerManagerFactory IslandElementContainerManagerFactory){
    }
    public virtual void IslandPositionChanged(){}
    public virtual void RelativeToContainerPositionChanged(){}
  }
}
