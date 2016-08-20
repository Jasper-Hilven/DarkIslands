namespace DarkIslands{
  public class WorldObjectUnityViewDefault: IWorldObjectChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(WorldObject WorldObject, WorldObjectUnityViewFactory WorldObjectUnityViewFactory){
    }
    public virtual void NameChanged(){}
    public virtual void PositionChanged(){}
    public virtual void HarvestControllerChanged(){}
    public virtual void TypeChanged(){}
  }
}
