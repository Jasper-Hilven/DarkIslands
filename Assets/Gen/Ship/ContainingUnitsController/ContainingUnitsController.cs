using System.Collections.Generic;
namespace DarkIslands
{
  public partial class ContainingUnitsController:ContainingUnitsControllerDefault
  {
    public ContainingUnitsController(Ship Ship, ContainingUnitsControllerFactory ContainingUnitsControllerFactory){
    Init(Ship, ContainingUnitsControllerFactory);
    }
  }
}
