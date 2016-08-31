namespace DarkIslands{
  public class IslandElementActionHandlerDefault: IIslandElementCurrentCommandChanged, IIslandElementCurrentActionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementActionHandlerFactory IslandElementActionHandlerFactory){
    }
    public virtual void CurrentCommandChanged(){}
    public virtual void CurrentActionChanged(){}
  }
}
