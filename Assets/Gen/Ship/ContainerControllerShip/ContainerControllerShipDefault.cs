namespace DarkIslands{
  public class ContainerControllerShipDefault: IShipChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Ship Ship, ContainerControllerShipFactory ContainerControllerShipFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SpeedChanged(){}
    public virtual void LifePointsChanged(){}
    public virtual void ItemsChanged(){}
    public virtual void UnitContainerControllerChanged(){}
  }
}
