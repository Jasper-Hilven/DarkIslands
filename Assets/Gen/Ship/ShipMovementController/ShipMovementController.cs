using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ShipMovementController:ShipMovementControllerDefault
  {
    public ShipMovementController(Ship Ship, ShipMovementControllerFactory ShipMovementControllerFactory){
    Init(Ship, ShipMovementControllerFactory);
    }
  }
}
