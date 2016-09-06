namespace DarkIslands{
  public class IslandElementSizeControllerDefault: IIslandElementHarvestInfoChanged, IIslandElementSizeControllerChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementSizeControllerFactory IslandElementSizeControllerFactory){
    }
    public virtual void HarvestInfoChanged(){}
    public virtual void SizeControllerChanged(){}
  }
}
