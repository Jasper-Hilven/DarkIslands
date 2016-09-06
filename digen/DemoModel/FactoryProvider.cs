namespace DarkIslandGen.DemoModel
{
    public class FactoryProvider
    {
        public ShipFactory GetShipFactory()
        {
            var shipFactory = new ShipFactory();
            shipFactory.SubFactories.Add(new ShipViewModelFactory());
            return shipFactory;
        } 
    }
}