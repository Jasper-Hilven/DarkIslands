namespace DarkIslands{
  public class UnitMovementControllerDefault: IUnitChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory){
    }
    public virtual void ElementTypeChanged(){}
    public virtual void RelativeGoalPositionChanged(){}
    public virtual void HasRelativeGoalPositionChanged(){}
    public virtual void MaxSpeedChanged(){}
    public virtual void PositionChanged(){}
    public virtual void ContainerPositionChanged(){}
    public virtual void RelativeToContainerPositionChanged(){}
    public virtual void ContainerChanged(){}
    public virtual void ContainerToEnterChanged(){}
    public virtual void CurrentActionChanged(){}
    public virtual void CurrentCommandChanged(){}
    public virtual void hasLightChanged(){}
    public virtual void hasElementViewChanged(){}
    public virtual void ElementInfoChanged(){}
    public virtual void WOContainerControllerChanged(){}
  }
}
