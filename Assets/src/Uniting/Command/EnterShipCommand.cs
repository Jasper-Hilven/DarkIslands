namespace DarkIslands
{
    public class EnterShipCommand:IUnitCommand
    {
        public EnterShipCommand(Ship Ship)
        {
            this.Ship = Ship;
        }

        public Ship Ship { get; set; }
    }
}