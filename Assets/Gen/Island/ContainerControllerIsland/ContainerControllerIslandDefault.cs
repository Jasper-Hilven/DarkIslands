namespace DarkIslands{
  public class ContainerControllerIslandDefault: IIslandContainerControllerIslandChanged, IIslandPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, ContainerControllerIslandFactory ContainerControllerIslandFactory){
    }
    public virtual void ContainerControllerIslandChanged(){}
    public virtual void PositionChanged(){}
  }
}
