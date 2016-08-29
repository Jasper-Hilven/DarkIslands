namespace DarkIslands{
  public class InterIslandCollisionDefault: IIslandChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(Island Island, InterIslandCollisionFactory InterIslandCollisionFactory){
    }
    public virtual void PositionChanged(){}
    public virtual void SizeChanged(){}
    public virtual void ContainerControllerIslandChanged(){}
    public virtual void IslandCollisionChanged(){}
    public virtual void CircleElementPropertiesChanged(){}
  }
}
