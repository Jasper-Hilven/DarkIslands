namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory;
    public IslandUnityViewFactory IslandUnityViewFactory;
    public ShipFactory ShipFactory;
    public ShipUnityViewFactory ShipUnityViewFactory;
    public ShipPlayerControllerFactory ShipPlayerControllerFactory;
    public ShipSelectedViewFactory ShipSelectedViewFactory;
    public ShipMovementControllerFactory ShipMovementControllerFactory;
    public UnitFactory UnitFactory;
    public UnitUnityViewFactory UnitUnityViewFactory;
    public UnitMovementControllerFactory UnitMovementControllerFactory;
    public void Initialize(){
      var CollisionProvider= new CollisionProvider();
      this.IslandFactory= new IslandFactory();
      this.IslandUnityViewFactory= new IslandUnityViewFactory();
      this.ShipFactory= new ShipFactory();
      this.ShipUnityViewFactory= new ShipUnityViewFactory();
      this.ShipPlayerControllerFactory= new ShipPlayerControllerFactory();
      this.ShipSelectedViewFactory= new ShipSelectedViewFactory();
      this.ShipMovementControllerFactory= new ShipMovementControllerFactory();
      this.UnitFactory= new UnitFactory();
      this.UnitUnityViewFactory= new UnitUnityViewFactory();
      this.UnitMovementControllerFactory= new UnitMovementControllerFactory();
      IslandFactory.SubFactories.Add(IslandUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipPlayerControllerFactory);
      ShipFactory.SubFactories.Add(ShipSelectedViewFactory);
      ShipFactory.SubFactories.Add(ShipMovementControllerFactory);
      UnitFactory.SubFactories.Add(UnitUnityViewFactory);
      UnitFactory.SubFactories.Add(UnitMovementControllerFactory);
    }
  }
}
