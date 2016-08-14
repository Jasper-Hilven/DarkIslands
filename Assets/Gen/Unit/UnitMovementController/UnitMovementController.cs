using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitMovementController:UnitMovementControllerDefault
  {
    public UnitMovementController(Unit Unit, UnitMovementControllerFactory UnitMovementControllerFactory){
    Init(Unit, UnitMovementControllerFactory);
    }
  }
}
