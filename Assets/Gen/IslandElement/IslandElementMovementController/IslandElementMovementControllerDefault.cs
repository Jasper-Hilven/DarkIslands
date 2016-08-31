namespace DarkIslands{
  public class IslandElementMovementControllerDefault: IIslandElementRelativeToContainerPositionChanged, IIslandElementRelativeGoalPositionChanged, IIslandElementHasRelativeGoalPositionChanged, IIslandElementIslandPositionChanged, IIslandElementIslandChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementMovementControllerFactory IslandElementMovementControllerFactory){
    }
    public virtual void RelativeToContainerPositionChanged(){}
    public virtual void RelativeGoalPositionChanged(){}
    public virtual void HasRelativeGoalPositionChanged(){}
    public virtual void IslandPositionChanged(){}
    public virtual void IslandChanged(){}
  }
}
