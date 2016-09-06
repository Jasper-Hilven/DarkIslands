namespace DarkIslands{
  public class IslandUnityViewDefault: IIslandSizeChanged, IIslandPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, IslandUnityViewFactory IslandUnityViewFactory){
    }
    public virtual void SizeChanged(){}
    public virtual void PositionChanged(){}
  }
}
