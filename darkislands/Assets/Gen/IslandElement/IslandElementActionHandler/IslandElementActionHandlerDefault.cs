namespace DarkIslands{
  public class IslandElementActionHandlerDefault: IIslandElementCurrentCommandChanged, IIslandElementCurrentActionChanged, IIslandElementCurrentLifeActionChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementActionHandlerFactory IslandElementActionHandlerFactory){
    }
    public virtual void CurrentCommandChanged(){}
    public virtual void CurrentActionChanged(){}
    public virtual void CurrentLifeActionChanged(){}
  }
}
