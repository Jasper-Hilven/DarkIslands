namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory;
    public IslandUnityViewFactory IslandUnityViewFactory;
    public ContainerControllerIslandFactory ContainerControllerIslandFactory;
    public OnIslandCollisionFactory OnIslandCollisionFactory;
    public IslandElementFactory IslandElementFactory;
    public IslandElementUnityViewFactory IslandElementUnityViewFactory;
    public IslandElementMovementControllerFactory IslandElementMovementControllerFactory;
    public IslandElementActionHandlerFactory IslandElementActionHandlerFactory;
    public IslandElementContainerManagerFactory IslandElementContainerManagerFactory;
    public IslandElementLightControllerFactory IslandElementLightControllerFactory;
    public IslandElementElementalViewFactory IslandElementElementalViewFactory;
    public HarvestControllerFactory HarvestControllerFactory;
public ModelToEntity ModelToEntity= new ModelToEntity();
    public void Initialize(){
      this.IslandFactory= new IslandFactory();
      this.IslandUnityViewFactory= new IslandUnityViewFactory(ModelToEntity);
      this.ContainerControllerIslandFactory= new ContainerControllerIslandFactory();
      this.OnIslandCollisionFactory= new OnIslandCollisionFactory();
      this.IslandElementFactory= new IslandElementFactory();
      this.IslandElementUnityViewFactory= new IslandElementUnityViewFactory(ModelToEntity);
      this.IslandElementMovementControllerFactory= new IslandElementMovementControllerFactory();
      this.IslandElementActionHandlerFactory= new IslandElementActionHandlerFactory();
      this.IslandElementContainerManagerFactory= new IslandElementContainerManagerFactory();
      this.IslandElementLightControllerFactory= new IslandElementLightControllerFactory();
      this.IslandElementElementalViewFactory= new IslandElementElementalViewFactory();
      this.HarvestControllerFactory= new HarvestControllerFactory();
      IslandFactory.SubFactories.Add(IslandUnityViewFactory);
      IslandFactory.SubFactories.Add(ContainerControllerIslandFactory);
      IslandFactory.SubFactories.Add(OnIslandCollisionFactory);
      IslandElementFactory.SubFactories.Add(IslandElementUnityViewFactory);
      IslandElementFactory.SubFactories.Add(IslandElementMovementControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementActionHandlerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementContainerManagerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementLightControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementElementalViewFactory);
      IslandElementFactory.SubFactories.Add(HarvestControllerFactory);
    }
  }
}
