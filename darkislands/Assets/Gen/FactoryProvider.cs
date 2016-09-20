namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory;
    public IslandSizeControllerFactory IslandSizeControllerFactory;
    public IslandMovementControllerFactory IslandMovementControllerFactory;
    public ContainerControllerIslandFactory ContainerControllerIslandFactory;
    public OnIslandCollisionFactory OnIslandCollisionFactory;
    public InterIslandCollisionFactory InterIslandCollisionFactory;
    public IslandCollisionSizeManagerFactory IslandCollisionSizeManagerFactory;
    public OnIslandNearityControllerFactory OnIslandNearityControllerFactory;
    public IslandUnityViewFactory IslandUnityViewFactory;
    public IslandManaControllerFactory IslandManaControllerFactory;
    public IslandElementFactory IslandElementFactory;
    public InventoryControllerFactory InventoryControllerFactory;
    public IslandElementContainerManagerFactory IslandElementContainerManagerFactory;
    public NearOthersControllerFactory NearOthersControllerFactory;
    public IslandElementMovementControllerFactory IslandElementMovementControllerFactory;
    public IslandElementActionHandlerFactory IslandElementActionHandlerFactory;
    public IslandElementLightControllerFactory IslandElementLightControllerFactory;
    public HarvestControllerFactory HarvestControllerFactory;
    public IslandElementSizeControllerFactory IslandElementSizeControllerFactory;
    public CollisionSizeManagerFactory CollisionSizeManagerFactory;
    public IslandElementDropOffControllerFactory IslandElementDropOffControllerFactory;
    public IslandElementElementalControllerFactory IslandElementElementalControllerFactory;
    public IslandElementElementalViewFactory IslandElementElementalViewFactory;
    public IslandElementMagicControllerFactory IslandElementMagicControllerFactory;
    public IslandElementHydrationControllerFactory IslandElementHydrationControllerFactory;
    public IslandElementLifeControllerFactory IslandElementLifeControllerFactory;
    public IslandElementSpawnControllerFactory IslandElementSpawnControllerFactory;
    public IslandElementUnityViewFactory IslandElementUnityViewFactory;
    public IslandElementUnityAnimationControllerFactory IslandElementUnityAnimationControllerFactory;
    public IslandElementHoverControllerFactory IslandElementHoverControllerFactory;
    public IslandSelectionControllerFactory IslandSelectionControllerFactory;
    public IslandElementUnityStatsViewFactory IslandElementUnityStatsViewFactory;
    public IslandElementFightingControllerFactory IslandElementFightingControllerFactory;
    public IslandElementTeamControllerFactory IslandElementTeamControllerFactory;
public ModelToEntity ModelToEntity= new ModelToEntity();
    public void Initialize(){
      this.IslandFactory= new IslandFactory();
      this.IslandSizeControllerFactory= new IslandSizeControllerFactory();
      this.IslandMovementControllerFactory= new IslandMovementControllerFactory();
      this.ContainerControllerIslandFactory= new ContainerControllerIslandFactory();
      this.OnIslandCollisionFactory= new OnIslandCollisionFactory();
      this.InterIslandCollisionFactory= new InterIslandCollisionFactory();
      this.IslandCollisionSizeManagerFactory= new IslandCollisionSizeManagerFactory();
      this.OnIslandNearityControllerFactory= new OnIslandNearityControllerFactory();
      this.IslandUnityViewFactory= new IslandUnityViewFactory(ModelToEntity);
      this.IslandManaControllerFactory= new IslandManaControllerFactory();
      this.IslandElementFactory= new IslandElementFactory();
      this.InventoryControllerFactory= new InventoryControllerFactory();
      this.IslandElementContainerManagerFactory= new IslandElementContainerManagerFactory();
      this.NearOthersControllerFactory= new NearOthersControllerFactory();
      this.IslandElementMovementControllerFactory= new IslandElementMovementControllerFactory();
      this.IslandElementActionHandlerFactory= new IslandElementActionHandlerFactory();
      this.IslandElementLightControllerFactory= new IslandElementLightControllerFactory();
      this.HarvestControllerFactory= new HarvestControllerFactory();
      this.IslandElementSizeControllerFactory= new IslandElementSizeControllerFactory();
      this.CollisionSizeManagerFactory= new CollisionSizeManagerFactory();
      this.IslandElementDropOffControllerFactory= new IslandElementDropOffControllerFactory();
      this.IslandElementElementalControllerFactory= new IslandElementElementalControllerFactory();
      this.IslandElementElementalViewFactory= new IslandElementElementalViewFactory();
      this.IslandElementMagicControllerFactory= new IslandElementMagicControllerFactory();
      this.IslandElementHydrationControllerFactory= new IslandElementHydrationControllerFactory();
      this.IslandElementLifeControllerFactory= new IslandElementLifeControllerFactory();
      this.IslandElementSpawnControllerFactory= new IslandElementSpawnControllerFactory();
      this.IslandElementUnityViewFactory= new IslandElementUnityViewFactory(ModelToEntity);
      this.IslandElementUnityAnimationControllerFactory= new IslandElementUnityAnimationControllerFactory(ModelToEntity);
      this.IslandElementHoverControllerFactory= new IslandElementHoverControllerFactory();
      this.IslandSelectionControllerFactory= new IslandSelectionControllerFactory();
      this.IslandElementUnityStatsViewFactory= new IslandElementUnityStatsViewFactory();
      this.IslandElementFightingControllerFactory= new IslandElementFightingControllerFactory();
      this.IslandElementTeamControllerFactory= new IslandElementTeamControllerFactory();
      IslandFactory.SubFactories.Add(IslandSizeControllerFactory);
      IslandFactory.SubFactories.Add(IslandMovementControllerFactory);
      IslandFactory.SubFactories.Add(ContainerControllerIslandFactory);
      IslandFactory.SubFactories.Add(OnIslandCollisionFactory);
      IslandFactory.SubFactories.Add(InterIslandCollisionFactory);
      IslandFactory.SubFactories.Add(IslandCollisionSizeManagerFactory);
      IslandFactory.SubFactories.Add(OnIslandNearityControllerFactory);
      IslandFactory.SubFactories.Add(IslandUnityViewFactory);
      IslandFactory.SubFactories.Add(IslandManaControllerFactory);
      IslandElementFactory.SubFactories.Add(InventoryControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementContainerManagerFactory);
      IslandElementFactory.SubFactories.Add(NearOthersControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementMovementControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementActionHandlerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementLightControllerFactory);
      IslandElementFactory.SubFactories.Add(HarvestControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementSizeControllerFactory);
      IslandElementFactory.SubFactories.Add(CollisionSizeManagerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementDropOffControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementElementalControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementElementalViewFactory);
      IslandElementFactory.SubFactories.Add(IslandElementMagicControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementHydrationControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementLifeControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementSpawnControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementUnityViewFactory);
      IslandElementFactory.SubFactories.Add(IslandElementUnityAnimationControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementHoverControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandSelectionControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementUnityStatsViewFactory);
      IslandElementFactory.SubFactories.Add(IslandElementFightingControllerFactory);
      IslandElementFactory.SubFactories.Add(IslandElementTeamControllerFactory);
    }
  }
}
