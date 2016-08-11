namespace DarkIslands
{
  public class FactoryProvider
  {
    public IslandFactory IslandFactory= new IslandFactory();
    public IslandViewFactory IslandViewFactory= new IslandViewFactory();
    public ShipFactory ShipFactory= new ShipFactory();
    public ShipUnityViewFactory ShipUnityViewFactory= new ShipUnityViewFactory();
    public ShipPlayerControllerFactory ShipPlayerControllerFactory= new ShipPlayerControllerFactory();
    public ShipSelectedViewFactory ShipSelectedViewFactory= new ShipSelectedViewFactory();
    public ShipMovementControllerFactory ShipMovementControllerFactory= new ShipMovementControllerFactory();
    public void Initialize(){
      IslandFactory.SubFactories.Add(IslandViewFactory);
      ShipFactory.SubFactories.Add(ShipUnityViewFactory);
      ShipFactory.SubFactories.Add(ShipPlayerControllerFactory);
      ShipFactory.SubFactories.Add(ShipSelectedViewFactory);
      ShipFactory.SubFactories.Add(ShipMovementControllerFactory);
    }
  }
}
