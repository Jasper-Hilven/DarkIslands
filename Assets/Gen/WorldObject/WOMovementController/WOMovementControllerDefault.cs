namespace DarkIslands{
  public class WOMovementControllerDefault: IWorldObjectChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(WorldObject WorldObject, WOMovementControllerFactory WOMovementControllerFactory){
    }
    public virtual void NameChanged(){}
    public virtual void PositionChanged(){}
    public virtual void HarvestControllerChanged(){}
    public virtual void TypeChanged(){}
    public virtual void RelativePositionChanged(){}
    public virtual void ContainerPositionChanged(){}
    public virtual void ContainerChanged(){}
  }
}
