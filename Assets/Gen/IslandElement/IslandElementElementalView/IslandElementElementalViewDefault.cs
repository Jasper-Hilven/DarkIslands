namespace DarkIslands{
  public class IslandElementElementalViewDefault: IIslandElementIsElementalColoredChanged, IIslandElementhasElementalViewChanged, IIslandElementElementalInfoChanged, IIslandElementElementalTypeChanged
  {
    public virtual void Destroy(){
    }
    public virtual void Init(IslandElement IslandElement, IslandElementElementalViewFactory IslandElementElementalViewFactory){
    }
    public virtual void IsElementalColoredChanged(){}
    public virtual void hasElementalViewChanged(){}
    public virtual void ElementalInfoChanged(){}
    public virtual void ElementalTypeChanged(){}
  }
}
