namespace DarkIslandGen.DemoModel
{
    public class ShipViewModel:ShipViewModelDefault
    {
        //Child only
        public Ship Ship { get; set; }

        public ShipViewModel(Ship ship)
        {
            Ship = ship;
        }

    }
}