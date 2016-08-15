namespace DarkIslands{
  public class ContainingUnitsControllerDefault: IShipChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Ship Ship, ContainingUnitsControllerFactory ContainingUnitsControllerFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SpeedChanged(){}
    public virtual void InitializedChanged(){}
    public virtual void AliveChanged(){}
    public virtual void LifePointsChanged(){}
    public virtual void ItemsChanged(){}
    public virtual void TeamChanged(){}
    public virtual void ElementTypeChanged(){}
    public virtual void CurrentActionChanged(){}
    public virtual void NextActionsChanged(){}
    public virtual void ContainingUnitsChanged(){}
  }
}
