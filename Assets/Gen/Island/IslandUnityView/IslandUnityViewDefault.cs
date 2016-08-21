namespace DarkIslands{
  public class IslandUnityViewDefault: IIslandChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, IslandUnityViewFactory IslandUnityViewFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SizeChanged(){}
    public virtual void UnitContainerControllerChanged(){}
    public virtual void WOContainerControllerChanged(){}
  }
}
