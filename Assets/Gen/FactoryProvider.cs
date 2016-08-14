namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory;
    public IslandViewFactory IslandViewFactory;
    public ShipFactory ShipFactory;
    public ShipUnityViewFactory ShipUnityViewFactory;
    public ShipPlayerControllerFactory ShipPlayerControllerFactory;
    public ShipSelectedViewFactory ShipSelectedViewFactory;
    public ShipMovementControllerFactory ShipMovementControllerFactory;
    public void Initialize(){
      var CollisionProvider= new CollisionProvider();
      this.IslandFactory= new IslandFactory();
      this.IslandViewFactory= new IslandViewFactory();
      this.ShipFactory= new ShipFactory();
      this.ShipUnityViewFactory= new ShipUnityViewFactory();
      this.ShipPlayerControllerFactory= new ShipPlayerControllerFactory();
      this.ShipSelectedViewFactory= new ShipSelectedViewFactory();
      this.ShipMovementControllerFactory= new ShipMovementControllerFactory();
      IslandFactory.SubFactories.Add(IslandViewFactory);
      ShipFactory.SubFactories.Add(ShipUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipPlayerControllerFactory);
      ShipFactory.SubFactories.Add(ShipSelectedViewFactory);
      ShipFactory.SubFactories.Add(ShipMovementControllerFactory);
    }
  }
}
