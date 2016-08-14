namespace DarkIslands{
  public class UnitUnityViewDefault: IUnitChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Unit Unit, UnitUnityViewFactory UnitUnityViewFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void ElementTypeChanged(){}
    public virtual void intendedGoalPositionChanged(){}
    public virtual void intendedToMoveChanged(){}
    public virtual void MaxSpeedChanged(){}
  }
}
