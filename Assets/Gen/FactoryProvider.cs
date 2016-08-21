namespace DarkIslands
{
  public class FactoryProvider
  {
    public ShipFactory ShipFactory;
    public ShipUnityViewFactory ShipUnityViewFactory;
    public ShipPlayerControllerFactory ShipPlayerControllerFactory;
    public ShipSelectedViewFactory ShipSelectedViewFactory;
    public ContainerControllerShipFactory ContainerControllerShipFactory;
    public ShipMovementControllerFactory ShipMovementControllerFactory;
    public IWOContainerControllerShipFactory IWOContainerControllerShipFactory;
    public IslandFactory IslandFactory;
    public IslandUnityViewFactory IslandUnityViewFactory;
    public ContainerControllerIslandFactory ContainerControllerIslandFactory;
    public IWOContainerControllerIslandFactory IWOContainerControllerIslandFactory;
    public UnitFactory UnitFactory;
    public UnitUnityViewFactory UnitUnityViewFactory;
    public UnitMovementControllerFactory UnitMovementControllerFactory;
    public UnitActionHandlerFactory UnitActionHandlerFactory;
    public UnitContainerManagerFactory UnitContainerManagerFactory;
    public IWOContainerControllerUnitFactory IWOContainerControllerUnitFactory;
    public UnitLightControllerFactory UnitLightControllerFactory;
    public UnitELementViewFactory UnitELementViewFactory;
    public WOHarvestControllerFactory WOHarvestControllerFactory;
    public WorldObjectFactory WorldObjectFactory;
    public WorldObjectUnityViewFactory WorldObjectUnityViewFactory;
    public WOMovementControllerFactory WOMovementControllerFactory;
    public WOContainerManagerFactory WOContainerManagerFactory;
public ModelToEntity ModelToEntity= new ModelToEntity();
    public void Initialize(){
var CollisionProvider= new CollisionProvider();
      this.ShipFactory= new ShipFactory();
      this.ShipUnityViewFactory= new ShipUnityViewFactory(ModelToEntity);
      this.ShipPlayerControllerFactory= new ShipPlayerControllerFactory();
      this.ShipSelectedViewFactory= new ShipSelectedViewFactory();
      this.ContainerControllerShipFactory= new ContainerControllerShipFactory();
      this.ShipMovementControllerFactory= new ShipMovementControllerFactory();
      this.IWOContainerControllerShipFactory= new IWOContainerControllerShipFactory();
      this.IslandFactory= new IslandFactory();
      this.IslandUnityViewFactory= new IslandUnityViewFactory(ModelToEntity);
      this.ContainerControllerIslandFactory= new ContainerControllerIslandFactory();
      this.IWOContainerControllerIslandFactory= new IWOContainerControllerIslandFactory();
      this.UnitFactory= new UnitFactory();
      this.UnitUnityViewFactory= new UnitUnityViewFactory();
      this.UnitMovementControllerFactory= new UnitMovementControllerFactory();
      this.UnitActionHandlerFactory= new UnitActionHandlerFactory();
      this.UnitContainerManagerFactory= new UnitContainerManagerFactory();
      this.IWOContainerControllerUnitFactory= new IWOContainerControllerUnitFactory();
      this.UnitLightControllerFactory= new UnitLightControllerFactory();
      this.UnitELementViewFactory= new UnitELementViewFactory();
      this.WOHarvestControllerFactory= new WOHarvestControllerFactory();
      this.WorldObjectFactory= new WorldObjectFactory();
      this.WorldObjectUnityViewFactory= new WorldObjectUnityViewFactory(ModelToEntity);
      this.WOMovementControllerFactory= new WOMovementControllerFactory();
      this.WOContainerManagerFactory= new WOContainerManagerFactory();
      ShipFactory.SubFactories.Add(ShipUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipPlayerControllerFactory);
      ShipFactory.SubFactories.Add(ShipSelectedViewFactory);
      ShipFactory.SubFactories.Add(ContainerControllerShipFactory);
      ShipFactory.SubFactories.Add(ShipMovementControllerFactory);
      ShipFactory.SubFactories.Add(IWOContainerControllerShipFactory);
      IslandFactory.SubFactories.Add(IslandUnityViewFactory);
      IslandFactory.SubFactories.Add(ContainerControllerIslandFactory);
      IslandFactory.SubFactories.Add(IWOContainerControllerIslandFactory);
      UnitFactory.SubFactories.Add(UnitUnityViewFactory);
      UnitFactory.SubFactories.Add(UnitMovementControllerFactory);
      UnitFactory.SubFactories.Add(UnitActionHandlerFactory);
      UnitFactory.SubFactories.Add(UnitContainerManagerFactory);
      UnitFactory.SubFactories.Add(IWOContainerControllerUnitFactory);
      UnitFactory.SubFactories.Add(UnitLightControllerFactory);
      UnitFactory.SubFactories.Add(UnitELementViewFactory);
      WorldObjectFactory.SubFactories.Add(WOHarvestControllerFactory);
      WorldObjectFactory.SubFactories.Add(WorldObjectUnityViewFactory);
      WorldObjectFactory.SubFactories.Add(WOMovementControllerFactory);
      WorldObjectFactory.SubFactories.Add(WOContainerManagerFactory);
    }
  }
}
