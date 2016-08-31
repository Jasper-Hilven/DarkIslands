namespace DarkIslands{
  public class IslandElementLightControllerDefault: IIslandElementhasLightChanged, IIslandElementPositionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementLightControllerFactory IslandElementLightControllerFactory){
    }
    public virtual void hasLightChanged(){}
    public virtual void PositionChanged(){}
  }
}
