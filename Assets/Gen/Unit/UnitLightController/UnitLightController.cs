using System.Collections.Generic;
namespace DarkIslands
{
  public partial class UnitLightController:UnitLightControllerDefault
  {
    public UnitLightController(Unit Unit, UnitLightControllerFactory UnitLightControllerFactory){
    Init(Unit, UnitLightControllerFactory);
    }
  }
}
