namespace DarkIslandGen.DemoModel
{
    public partial class ShipViewModel:ShipViewModelDefault
    {
        //Child only
        public Ship Ship { get; set; }

        public ShipViewModel(Ship ship)
        {
            this.Ship = ship;
        }

    }
}