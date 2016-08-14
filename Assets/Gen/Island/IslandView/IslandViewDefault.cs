namespace DarkIslands{
  public class IslandViewDefault: IIslandChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, IslandViewFactory IslandViewFactory){
    }
    public virtual void PositionChanged(){}
  }
}
