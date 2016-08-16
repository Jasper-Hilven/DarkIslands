namespace DarkIslands{
  public class ShipUnityViewDefault: IShipChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Ship Ship, ShipUnityViewFactory ShipUnityViewFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SpeedChanged(){}
    public virtual void LifePointsChanged(){}
    public virtual void ItemsChanged(){}
    public virtual void UnitContainerControllerChanged(){}
  }
}
