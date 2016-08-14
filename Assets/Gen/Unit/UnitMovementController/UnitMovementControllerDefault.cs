namespace DarkIslands{
  public class UnitMovementControllerDefault: IUnitChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void ElementTypeChanged(){}
    public virtual void intendedGoalPositionChanged(){}
    public virtual void MaxSpeedChanged(){}
  }
}
