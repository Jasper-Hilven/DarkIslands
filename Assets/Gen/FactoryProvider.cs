namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory;
    public IslandUnityViewFactory IslandUnityViewFactory;
    public ContainerControllerIslandFactory ContainerControllerIslandFactory;
    public ShipFactory ShipFactory;
    public ShipUnityViewFactory ShipUnityViewFactory;
    public ShipPlayerControllerFactory ShipPlayerControllerFactory;
    public ShipSelectedViewFactory ShipSelectedViewFactory;
    public ContainerControllerShipFactory ContainerControllerShipFactory;
    public UnitFactory UnitFactory;
    public UnitUnityViewFactory UnitUnityViewFactory;
    public UnitMovementControllerFactory UnitMovementControllerFactory;
    public UnitActionHandlerFactory UnitActionHandlerFactory;
    public UnitContainerManagerFactory UnitContainerManagerFactory;
public ModelToEntity ModelToEntity= new ModelToEntity();
    public void Initialize(){
var CollisionProvider= new CollisionProvider();
      this.IslandFactory= new IslandFactory();
      this.IslandUnityViewFactory= new IslandUnityViewFactory(ModelToEntity);
      this.ContainerControllerIslandFactory= new ContainerControllerIslandFactory();
      this.ShipFactory= new ShipFactory();
      this.ShipUnityViewFactory= new ShipUnityViewFactory(ModelToEntity);
      this.ShipPlayerControllerFactory= new ShipPlayerControllerFactory();
      this.ShipSelectedViewFactory= new ShipSelectedViewFactory();
      this.ContainerControllerShipFactory= new ContainerControllerShipFactory();
      this.UnitFactory= new UnitFactory();
      this.UnitUnityViewFactory= new UnitUnityViewFactory();
      this.UnitMovementControllerFactory= new UnitMovementControllerFactory();
      this.UnitActionHandlerFactory= new UnitActionHandlerFactory();
      this.UnitContainerManagerFactory= new UnitContainerManagerFactory();
      IslandFactory.SubFactories.Add(IslandUnityViewFactory);
      IslandFactory.SubFactories.Add(ContainerControllerIslandFactory);
      ShipFactory.SubFactories.Add(ShipUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipPlayerControllerFactory);
      ShipFactory.SubFactories.Add(ShipSelectedViewFactory);
      ShipFactory.SubFactories.Add(ContainerControllerShipFactory);
      UnitFactory.SubFactories.Add(UnitUnityViewFactory);
      UnitFactory.SubFactories.Add(UnitMovementControllerFactory);
      UnitFactory.SubFactories.Add(UnitActionHandlerFactory);
      UnitFactory.SubFactories.Add(UnitContainerManagerFactory);
    }
  }
}
