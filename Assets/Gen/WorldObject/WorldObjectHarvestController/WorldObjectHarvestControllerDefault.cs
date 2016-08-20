namespace DarkIslands{
  public class WorldObjectHarvestControllerDefault: IWorldObjectChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(WorldObject WorldObject, WorldObjectHarvestControllerFactory WorldObjectHarvestControllerFactory){
    }
    public virtual void NameChanged(){}
    public virtual void PositionChanged(){}
    public virtual void HarvestControllerChanged(){}
    public virtual void TypeChanged(){}
  }
}
