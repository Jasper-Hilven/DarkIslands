namespace DarkIslands{
  public class ContainerControllerIslandDefault: IIslandChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, ContainerControllerIslandFactory ContainerControllerIslandFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SizeChanged(){}
    public virtual void UnitContainerControllerChanged(){}
  }
}
