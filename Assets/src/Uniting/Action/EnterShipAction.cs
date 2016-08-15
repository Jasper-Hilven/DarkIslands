namespace DarkIslands
{
    public class EnterShipAction:IUnitAction
    {
        public EnterShipAction(Ship ship)
        {
            this.Ship = ship;
        }

        public Ship Ship { get; set; }
    }
}