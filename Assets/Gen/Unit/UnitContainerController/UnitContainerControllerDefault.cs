namespace DarkIslands{
  public class UnitContainerControllerDefault: IUnitChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Unit Unit, UnitContainerControllerFactory UnitContainerControllerFactory){
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
  }
}
