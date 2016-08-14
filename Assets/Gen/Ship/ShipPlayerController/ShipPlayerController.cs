using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipPlayerController:ShipPlayerControllerDefault
  {
    public ShipPlayerController(Ship Ship, ShipPlayerControllerFactory ShipPlayerControllerFactory){
    Init(Ship, ShipPlayerControllerFactory);
    }
  }
}
