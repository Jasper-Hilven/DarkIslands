namespace DarkIslands{
  public class UnitUnityViewDefault: IUnitChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Unit Unit, UnitUnityViewFactory UnitUnityViewFactory){
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
    public virtual void IWOContainerControllerChanged(){}
  }
}
